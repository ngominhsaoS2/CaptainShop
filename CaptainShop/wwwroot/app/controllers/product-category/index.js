var ProductCategoryController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        $('#btnCreate').off('click').on('click', function () {
            initTreeDropDownCategory();
            $('#modal-add-edit').modal('show');
        });

        $('body').on('click', '#btnEdit', function (e) {
            e.preventDefault();
            var that = $('#hidIdM').val();
            $.ajax({
                type: "GET",
                url: "/Admin/ProductCategory/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    commonFunctions.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#hidIdM').val(data.Id);
                    $('#txtNameM').val(data.Name);

                    //Đẩy dữ liệu vào DropDownList Category
                    initTreeDropDownCategory(data.CategoryId);

                    $('#txtDescM').val(data.Description);

                    $('#txtImage').val(data.Image);

                    $('#txtSeoKeywordM').val(data.SeoKeywords);
                    $('#txtSeoDescriptionM').val(data.SeoDescription);
                    $('#txtSeoPageTitleM').val(data.SeoPageTitle);
                    $('#txtSeoAliasM').val(data.SeoAlias);

                    $('#ckStatusM').prop('checked', data.Status == 1);
                    $('#ckShowHomeM').prop('checked', data.HomeFlag);
                    $('#txtOrderM').val(data.SortOrder);
                    $('#txtHomeOrderM').val(data.HomeOrder);

                    $('#modal-add-edit').modal('show');
                    commonFunctions.stopLoading();

                },
                error: function (status) {
                    commonFunctions.notify('An error occured', 'error');
                    commonFunctions.stopLoading();
                }
            });
        });

        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'en',
            rules: {
                txtNameM: { required: true },
                txtOrderM: { number: true },
                txtHomeOrderM: { number: true }
            }
        });

        $('#btnSelectImg').on('click', function () {
            $('#fileInputImage').click();
        });

        $("#fileInputImage").on('change', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            $.ajax({
                type: "POST",
                url: "/Admin/Upload/UploadImage",
                contentType: false,
                processData: false,
                data: data,
                success: function (path) {
                    $('#txtImage').val(path);
                    commonFunctions.notify('Upload image succesfully!', 'success');

                },
                error: function () {
                    commonFunctions.notify('There was error uploading files!', 'error');
                }
            });
        });

        $('#btnSave').on('click', function (e) {
            if ($('#frmMaintainance').valid()) {
                e.preventDefault();
                var id = parseInt($('#hidIdM').val());
                var name = $('#txtNameM').val();
                var parentId = $('#ddlCategoryIdM').combotree('getValue');
                var description = $('#txtDescM').val();
                var image = $('#txtImage').val();
                var order = parseInt($('#txtOrderM').val());
                var homeOrder = $('#txtHomeOrderM').val();
                var seoKeyword = $('#txtSeoKeywordM').val();
                var seoMetaDescription = $('#txtSeoDescriptionM').val();
                var seoPageTitle = $('#txtSeoPageTitleM').val();
                var seoAlias = $('#txtSeoAliasM').val();
                var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;
                var showHome = $('#ckShowHomeM').prop('checked');

                $.ajax({
                    type: "POST",
                    url: "/Admin/ProductCategory/SaveEntity",
                    data: {
                        Id: id,
                        Name: name,
                        Description: description,
                        ParentId: parentId,
                        HomeOrder: homeOrder,
                        SortOrder: order,
                        HomeFlag: showHome,
                        Image: image,
                        Status: status,
                        SeoPageTitle: seoPageTitle,
                        SeoAlias: seoAlias,
                        SeoKeywords: seoKeyword,
                        SeoDescription: seoMetaDescription
                    },
                    dataType: "json",
                    beforeSend: function () {
                        commonFunctions.startLoading();
                    },
                    success: function (response) {
                        commonFunctions.notify('Update successfully', 'success');
                        $('#modal-add-edit').modal('hide');

                        resetFormMaintainance();

                        commonFunctions.stopLoading();
                        loadData(true);
                    },
                    error: function () {
                        commonFunctions.notify('Has an error in update progress', 'error');
                        commonFunctions.stopLoading();
                    }
                });
            }
            return false;
        });

        $('body').on('click', '#btnDelete', function (e) {
            e.preventDefault();
            var that = $('#hidIdM').val();
            commonFunctions.confirm('Are you sure to delete this item?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/ProductCategory/Delete",
                    data: { id: that },
                    dataType: "JSON",
                    beforeSend: function () {
                        commonFunctions.startLoading();
                    },
                    success: function (response) {
                        commonFunctions.notify('Delete successfully', 'success');
                        commonFunctions.stopLoading();
                        loadData();
                    },
                    error: function (status) {
                        commonFunctions.notify('Has an error in deleting progress', 'error');
                        commonFunctions.stopLoading();
                    }
                });
            });
        });
    }

    function initTreeDropDownCategory(selectedId) {
        $.ajax({
            url: "/Admin/ProductCategory/GetAll",
            type: 'GET',
            dataType: 'JSON',
            async: false,
            success: function (response) {
                var data = [];
                $.each(response, function (i, item) {
                    data.push({
                        id: item.Id,
                        text: item.Name,
                        parentId: item.ParentId,
                        sortOrder: item.SortOrder
                    });
                });
                var arr = commonFunctions.unflattern(data);
                $('#ddlCategoryIdM').combotree({
                    data: arr
                });
                if (selectedId != undefined) {
                    $('#ddlCategoryIdM').combotree('setValue', selectedId);
                }
            }
        });
    }

    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtNameM').val('');
        initTreeDropDownCategory('');

        $('#txtDescM').val('');
        $('#txtOrderM').val('');
        $('#txtHomeOrderM').val('');
        $('#txtImage').val('');

        $('#txtMetakeywordM').val('');
        $('#txtMetaDescriptionM').val('');
        $('#txtSeoPageTitleM').val('');
        $('#txtSeoAliasM').val('');

        $('#ckStatusM').prop('checked', true);
        $('#ckShowHomeM').prop('checked', false);
    }

    function loadData() {
        $.ajax({
            url: '/Admin/ProductCategory/GetAll',
            dataType: 'JSON',
            success: function (response) {
                var data = [];
                $.each(response, function (i, item) {
                    data.push({
                        id: item.Id,
                        text: item.Name,
                        parentId: item.ParentId,
                        sortOrder: item.SortOrder
                    });

                });
                var treeArr = commonFunctions.unflattern(data);
                treeArr.sort(function (a, b) {
                    return a.sortOrder - b.sortOrder;
                });

                $('#treeProductCategory').tree({
                    data: treeArr,
                    dnd: true, //bật tắt chức năng kéo thả

                    //Thực hiện khi right click vào một node, trong trường hợp này sẽ hiển thị ContextMenu
                    onContextMenu: function (e, node) {
                        e.preventDefault();
                        // select the node (gán id của node vào một ô hidden)
                        $('#hidIdM').val(node.id);
                        // display context menu
                        $('#contextMenu').menu('show', {
                            left: e.pageX,
                            top: e.pageY
                        });
                    },

                    //Thực hiện khi có sự kiện onDrop (thả item)
                    onDrop: function (target, source, point) {
                        console.log(target);
                        console.log(source);
                        console.log(point);
                        var targetNode = $(this).tree('getNode', target);
                        if (point === 'append') {
                            var children = [];
                            $.each(targetNode.children, function (i, item) {
                                children.push({
                                    key: item.id,
                                    value: i
                                });
                            });

                            //Update to database
                            $.ajax({
                                url: '/Admin/ProductCategory/UpdateParentId',
                                type: 'post',
                                dataType: 'json',
                                data: {
                                    sourceId: source.id,
                                    targetId: targetNode.id,
                                    items: children
                                },
                                success: function (res) {
                                    loadData();
                                }
                            });
                        }
                        else if (point === 'top' || point === 'bottom') {
                            $.ajax({
                                url: '/Admin/ProductCategory/ReOrder',
                                type: 'post',
                                dataType: 'json',
                                data: {
                                    sourceId: source.id,
                                    targetId: targetNode.id
                                },
                                success: function (res) {
                                    loadData();
                                }
                            });
                        }
                    }
                });

            }
        });
    }

}