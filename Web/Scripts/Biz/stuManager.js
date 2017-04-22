$(function () {

    var stuManager = function () {
        var $table = $("#myTable");

        var defaults = {
            searchForm: {
                TeaGuid: "0",
            },
        }
        var vms = {
            searchVm: null,
        };
        var VueInit = function () {
            vms.searchVm = new Vue({
                el: '#app',
                data: {
                    searchForm: $.extend({}, defaults.searchForm),
                    teachers:[],
                    students: [],
                    studentGuid:''
                },
                mounted: function () {
                    var self = this;
                    $.ajax({
                        url: '/Admin/GetInitInfo',
                        type: 'get',
                        dataType: 'json',
                        success: function (res) {
                            console.log(res);
                            self.students = $.extend([], res.Students);
                            self.teachers = $.extend([], res.Teachers);
                            if (res.Teachers != null && res.Teachers.length > 0)
                                self.searchForm.TeaGuid = res.Teachers[0].RowGuid;
                            if (res.Students != null && res.Students.length > 0)
                                self.studentGuid = res.Students[0].RowGuid;
                            setTimeout(function () {
                                $('.StuGuid').select2({
                                    placeholder: "请选择学生...",
                                });
                                $('.StuGuid').on('select2:select', function (evt) {
                                    // Do something
                                    var data = evt.params.data.id;
                                    self.studentGuid = data;
                                });
                                $('.teaGuid').select2({
                                    placeholder: "请选择老师...",
                                });
                                $('.teaGuid').on('select2:select', function (evt) {
                                    // Do something
                                    var data = evt.params.data.id;
                                    self.searchForm.TeaGuid = data;
                                    $('#myTable').bootstrapTable('refresh');
                                });
                                $('#myTable').bootstrapTable('refresh');
                            }, 500)
                        }
                    });

                },
                methods: {
                    search: function () {
                        $('#myTable').bootstrapTable('refresh');
                    },
                    add: function () {
                        var self = this;
                        var param = {
                            teaGuid: self.searchForm.TeaGuid,
                            stuGuid: self.studentGuid
                        };
                        $.ajax({
                            url: '/Admin/InsertToTeacher',
                            data: param,
                            type: 'post',
                            dataType:'json',
                            success: function (res) {
                                if (res)
                                {
                                    toastr.info('添加成功', '');
                                    $('#myTable').bootstrapTable('refresh');
                                } else {
                                    toastr.error('添加失败', '');
                                }

                            }

                        })
                    }
                }
            });
        }


        var tableInit = function () {
            $table.bootstrapTable({
                url: '/Admin/GetInfo',
                dataType: "json",
                pagination: true, //分页
                queryParams: function (params) {
                    return $.extend({}, { pagesize: params.limit, offset: params.offset }, vms.searchVm.searchForm);
                },
                sidePagination: "server", //服务端处理分页
                columns: [{
                    field: 'UserName',
                    title: '学生名',
                }, {
                    field: 'LogonNo',
                    title: '学号'
                },  {
                    title: '操作',
                    align: 'center',
                    formatter: function () {
                        return '<a class="btn btn-danger btn-outline detail" href="javascript:void(0);"><i class="fa fa-trash"></i>删除</button>'
                    },
                    events: {
                        'click .detail': function (event, value, row, index) {
                            var param = {
                                stuGuid: row.RowGuid
                            };
                            $.ajax({
                                url: '/Admin/Delete',
                                type: 'post',
                                data: param,
                                success: function (res) {
                                    if (res) {
                                        toastr.info('删除成功', '');
                                        $('#myTable').bootstrapTable('refresh');
                                    } else {
                                        toastr.error('删除失败', '');
                                    }
                                }
                            });
                        }
                    }
                }],

            });
        };


        var init = function () {
            VueInit();
            tableInit();
        };

        init();
    }();
})