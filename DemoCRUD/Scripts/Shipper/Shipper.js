$(function () {

    $('#btnSearch').on('click', function () {
        if ($('#ConitionArea') != undefined) {
            $('#ConitionArea').submit();
        }
    });


    $('#diaEditShipper').dialog({
        autoOpen: false,
        modal: true,
        /*蓋住底頁*/
        width: 860,
        height: 320,
        resizable: true,
    });
});

function AddShipper() {

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


//@(item.ShipperID),@(item.CompanyName),@(item.Phone)
function EditShipper(ShipperID, CompanyName, Phone) {
    $('#editShipperID').text(ShipperID);
    $('#txtEditPhone').val(Phone);
    $('#txtEditCompanyName').val(CompanyName);
    $('#diaEditShipper').dialog('open');
}

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

function CancelEdit() {
    $('#diaEditShipper').dialog('close');
}

function DeleteShipper(ShipperID) { //DeleteShipper(String delShipperID)
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

