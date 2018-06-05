$(function () {

    // 修改Dialog 預設關閉
    $('#diaEditShipper').dialog({
        autoOpen: false,
        modal: true,
        width: 860,
        height: 320,
        resizable: true,
    });

});

function ClearSearchTextBox() {
    $('#txtPhone,#txtCompanyName').val('');
}

// 新增
function AddShipper() {

    if (confirm('是否確認要新增?')) {
        var _Phone = $.trim($('#txtAddPhone').val());
        var _CompanyName = $.trim($('#txtAddCompanyName').val());

        if (_Phone === '') {
            alert('請輸入要新增的電話');
            return false;
        }
        if (_CompanyName === '') {
            alert('請輸入要新增的公司名稱');
            return false;
        }
        var _Object = {
            Phone: _Phone,
            CompanyName: _CompanyName
        };

        $.ajax({
            type: "POST",
            url: '../Shipper/AddShipper',
            data: JSON.stringify(_Object),
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (_result) {
                if (_result.ReturnCode == '000') {
                    alert('新增成功');
                    if ($('#ConitionArea') != undefined) {
                        $('#ConitionArea').submit();
                    }
                }
                else {
                    alert(_result.ReturnMessage);
                }
            },
            error: function (error) {
                alert('error: ' + error);
            }
        });
    }
}

function ClearAddTextBox() {
    $('#txtAddPhone,#txtAddCompanyName').val('');
}

// 開啟修改視窗
function OpenEditDialog(ShipperID, CompanyName, Phone) {
    $('#editShipperID').text(ShipperID);
    $('#txtEditPhone').val(Phone);
    $('#txtEditCompanyName').val(CompanyName);
    $('#diaEditShipper').dialog('open');
}

// 儲存修改內容
function SaveEditShipper() {

    var _Phone = $.trim($('#txtEditPhone').val());
    var _CompanyName = $.trim($('#txtEditCompanyName').val());

    if (_Phone === '') {
        alert('請輸入要修改的電話');
        return false;
    }
    if (_CompanyName === '') {
        alert('請輸入要修改的公司名稱');
        return false;
    }

    var _Object = {
        ShipperID: $('#editShipperID').text(),
        Phone: _Phone,
        CompanyName: _CompanyName
    };

    $.ajax({
        type: "POST",
        url: '../Shipper/EditShipper',
        data: JSON.stringify(_Object),
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (_result) {
            if (_result.ReturnCode == '000') {
                alert('修改成功');
                if ($('#ConitionArea') != undefined) {
                    $('#ConitionArea').submit();
                    $('#diaEditShipper').dialog('close');
                }
            }
            else {
                alert(_result.ReturnMessage);
            }
        },
        error: function (error) {
            alert('error: ' + error);
        }
    });
}

// 取消修改
function CancelEdit() {
    $('#diaEditShipper').dialog('close');
}

// 刪除
function DeleteShipper(ShipperID) { 
    if (confirm('確認要刪除?')) {
        var _Object = {
            delShipperID: ShipperID
        };

        $.ajax({
            type: "POST",
            url: '../Shipper/DeleteShipper',
            data: JSON.stringify(_Object),
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (_result) {
                if (_result.ReturnCode == '000') {
                    alert('刪除成功');
                    if ($('#ConitionArea') != undefined) {
                        $('#ConitionArea').submit();
                    }
                }
                else {
                    alert(_result.ReturnMessage);
                }
            },
            error: function (error) {
                alert('error: ' + error);
            }
        });
    }
}

