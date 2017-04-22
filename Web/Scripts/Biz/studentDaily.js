$(function () {

    var studentDaily = function () {
        var $table = $("#myTable");
        var $modal = $("#myModal");

        var defaults = {
            searchForm: {
                StudentGuid: "0",
            },
        }
        var vms = {
            searchVm: null,
            detailVm:null
        };
        var VueInit = function () {
            vms.searchVm = new Vue({
                el: '#app',
                data: {
                    searchForm: $.extend({}, defaults.searchForm),
                    students: []
                },
                mounted: function () {
                    var self = this;
                    $.ajax({
                        url: '/Teacher/GetStudents',
                        type: 'get',
                        dataType: 'json',
                        success: function (res) {
                            console.log(res);
                            self.students = $.extend([], res.items);
                            setTimeout(function () {
                                $('.StuGuid').select2({
                                    placeholder: "请输入学生名",
                                });
                                $('.StuGuid').on('select2:select', function (evt) {
                                    // Do something
                                    var data = evt.params.data.id;
                                    self.searchForm.StudentGuid = data;
                                });
                            }, 500)
                        }
                    });

                },
                methods: {
                    search: function () {
                        $('#myTable').bootstrapTable('refresh');
                    },
                }
            });


            vms.detailVm = new Vue({
                el: '#detailInfo',
                data: {
                    detail: {}
                },
                mounted: function () {
                    var self = this;
                    $("#modalContent").markdown();
                },
                methods: {
                    show: function (rowGuid) {
                        var self = this;
                        $.ajax({
                            url: '/Teacher/GetDetailInfo',
                            type: 'get',
                            data: {
                                rowGuid:rowGuid
                            },
                            dataType: 'json',
                            success: function (res) {
                                self.detail = $.extend({}, res);
                                $modal.modal("show");
                            }
                        });
                    },
                }

            });
        }


        var tableInit = function () {
            $table.bootstrapTable({
                url: '/Teacher/GetTableDaily',
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
                    field: 'Date',
                    title: '日期'
                }, {
                    field: 'CreateTime',
                    title: '创建时间'
                }, {
                    title: '操作',
                    align:'center',
                    formatter: function () {
                        return '<a class="btn btn-primary btn-outline detail" href="javascript:void(0);"><i class="fa fa-bars"></i>详细</button>'
                    },
                    events: {
                        'click .detail': function (event, value, row, index) {
                            debugger
                            vms.detailVm.show(row.RowGuid);
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