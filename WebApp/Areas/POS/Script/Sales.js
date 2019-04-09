$(document).ready(function () {






    $(document).on("click", "a.category", function () {
        var categoryid = $(this).attr('id');

        GetProductDetails(categoryid)
    });

    $(document).on("click", "a.Product", function () {
        var productid = $(this).attr('id');

        if (isExist(productid.trim()) == false) {
            GetProductData(productid)
            $(this).addClass("disabled")
        }
        else {
            alert("Item Already Added");
        }


    });

    $('#BillTable tbody').on('click', '.delete', function () {

        $(this).closest('tr').remove();
        LoadTotal();
    });

    $('#BillTable tbody').on('change', '.TotalPrice', function () {

        LoadTotal();
    });


    $(document).on('change', '#Paid,#Discount', function () {

        LoadTotal();
    });



    $("#myModal").on("show.bs.modal", function (e) {
        var link = $(e.relatedTarget);
        $(this).find(".modal-body").load(link.attr("href"));

        var tittle = link.data('whatever')

        $(this).find(".modal-title").html(tittle);


        $(this).find(".btnModalSave").hide();

    });



    $("#myModal").on("click", ".SelectCustomer", function (e) {


        $('#myModal').modal('toggle');
        var CustomerName = $(this).closest('tr').children('td.CustomerName').text();
        var CustomerID = $(this).closest('tr').children('td.CustomerID').text();


        $("#SelectedCustomerID").html(CustomerID);
        $("#SelectedCustomerName").html("Customer :" + CustomerName);


    });

    $("#myModal").on("click", ".PaymentMode", function (e) {


        $('#myModal').modal('toggle');
        var Paymentmodeid = $(this).attr('id');
        var PAymentModename = $(this).text();
        $("#SelectedPaymentModeID").html(Paymentmodeid);
        $("#SelectedPaymentMode").html("Payment Mode :" + PAymentModename);


    });



    $("#submit").on("click", function () {


        var valid = this.form.checkValidity();

        if (valid) {
            event.preventDefault();
            $.blockUI()

            var isAllValid = isValidEntries();
            if (isAllValid) {
                var list = [];
                $('#BillTable tbody tr').each(function () {

                    var orderItem = {
                        InvoiceDetailID: $('.InvoiceDetailID', this).html(),
                        ProductId: $('.ProductID', this).html(),
                        Qty: parseFloat($('.Qty', this).html()),
                        InvoicePrice: $('.TotalPrice', this).val(),
                        TotalPrice: $('.TotalPrice', this).val(),


                    }
                    list.push(orderItem);
                });
                debugger

                if (list.length > 0) {
                    var data = {
                        PayMentModeId: $('#SelectedPaymentModeID').html(),
                        CustomerID: $("#SelectedCustomerID").html(),
                        InvoiceDate: $('#InvoiceDate').datepicker('getDate'),
                        Remark: $('#Remark').val(),
                        TotalBill: $('#TotalBill').text(),
                        PaidValue: $('#Paid').val(),
                        TotalDiscount: $('#Discount').val(),
                        Balance: $('#Balance').text(),
                        InvoiceDetails: list,
                    }
                    $.ajax({
                        type: 'POST',
                        url: $("#CreateURL").val(),
                        data: JSON.stringify(data),
                        contentType: 'application/json',
                        success: function (data) {
                            if (data.status) {

                                list = [];

                                $('#orderdetailsItems').empty();

                                $.unblockUI()






                                bootbox.alert("Sales Invoice Successfully saved!", function () {
                                    var newUrl = $("#DetailURL").val()
                                    window.location.href = newUrl.replace('__id__', data.model.InvoiceMasterId);
                                });







                            }
                            else {
                                alert('Error');
                            }
                            $('#submit').val('Save');
                        },
                        error: function (error) {
                            console.log(error);
                            $('#submit').val('Save');
                        }
                    });
                } else {

                    bootbox.alert("No Items Added!");
                    $.unblockUI()
                }





            }
            else {
                $.unblockUI()
            }
        }
    });






    function LoadTotal() {
        var sum = 0;
        $(".TotalPrice").each(function () {

            var a = $(this).val().toString()
            a = +a || 0
            sum = sum + parseFloat(a);
        });
        $("#TotalBill").text(Number((sum).toFixed(2)).toString())

        var discount = $("#Discount").val().toString()
        discount = +discount || 0

        var paid = $("#Paid").val().toString()
        paid = +paid || 0


        var balance = (parseFloat(sum.toString()) - parseFloat(paid.toString())) - parseFloat(discount.toString());
        $("#Balance").text(Number((balance).toFixed(2)).toString())

    }

    function GetProductDetails(id) {
        $("#Producttable").empty();
        //url: "/POS/Sales/GetProductList",
        debugger;
        $.ajax({
            type: "GET",
            url: $("#GetProductDetailsUrl").val(),
            data: { Id: id },
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                debugger;



                $.each(result, function () {
                    $.each(this, function (index, val) {

                        var existclass = ""
                        if (isExist(val.ProductID)) {
                            existclass = "disabled"
                        }




                        var tittle = "CP=" + val.CostPrice.toString() + "&#010SP=" + val.SellingPrice.toString() + "&#010SL=" + val.SerialNumber.toString();

                        var markup = "  <a id=" + val.ProductID + " href='#' class='btn btn-squared-default-plain btn-warning Product " + existclass + "' data-toggle='tooltip' data-placement='top' title=" + tittle + " > " +
                                     "   <br />" + val.ProductName + "</a> ";






                        $('#Producttable').append(markup);
                    });
                });









            },
            error: function (response) {
                debugger;
                alert('eror');
            }
        });
    }

    function GetProductData(id) {
        //url: "/POS/Sales/GetProductData",
        debugger;
        $.ajax({
            type: "GET",
            url: $("#GetProductDataUrl").val(),
            data: { Id: id },
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                debugger;

                $.each(result, function (index, val) {





                    var markup = " <tr> \
                                    <td  class='InvoiceDetailID' style=\"display:none;\"> 0</th> \
                                    <td style=\"display:none;\" class='ProductID'> " + val.ProductID + "</td> \
                                    <td class='ProductName'> " + val.ProductName + "</td> \
                                    <td class='Serial'>  " + val.SerialNumber + "</td> \
                                    <td class='Qty'> 1 </td> \
                                    <td class='CostPrice'> " + val.SellingPrice + "</td>\
                                    <td class='Price'>\
                                    <input type=\"number\" min=\"0\" step=\"any\"  class='TotalPrice form-control' value=" + val.SellingPrice + " oninput=\"validity.valid||(value='');\" /> \
                                    </td> \
                                    <td><img src=\"/Content/Images/download.jpg\" style=\"width: 20px;height: 20px;\" class='delete' /></td></tr > \
                                </tr> "


                    $('#BillTable tbody').append(markup);
                    LoadTotal();

                });









            },
            error: function (response) {
                debugger;
                alert('eror');
            }
        });
    }



    function isExist(currentval) {
        var ispresent = false
        $('.ProductID').each(function () {

            if ($(this).html().trim() == currentval) {

                ispresent = true;

            }
        });
        return ispresent;

    }





    function isValidEntries() {
        var PayMentModeId = $('#SelectedPaymentModeID').html().trim();
        var CustomerID = $("#SelectedCustomerID").html().trim();


        if (PayMentModeId) {
        }
        else {
            bootbox.alert("Select Payment Mode!");

            return false
        }
        if (CustomerID) {
        }
        else {
            bootbox.alert("Select Customer!");

            return false
        }


        return true

    }


});