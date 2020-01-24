function CloseModal() {
    $(".fade").modal('hide');
}
//ManageKennel 
$(document).ready(function () {



    $("#puppy-group-born").datetimepicker({
        numberOfMonths: 1,
        format: "Y-m-d",
        timepicker: false
    });

    $("#kennelDogdateofbirth").datetimepicker({
        numberOfMonths: 1,
        format: "Y-m-d",
        timepicker: false
    });
    // New form (puppy, kenneldog, puppygroup, customer, customerdog(?))
    $(document).on("submit", ".newForm", function (event) {

        event.preventDefault();
        var action = $(this).attr('action');

        var thisform = $(this);
        var formdata = new FormData($(this).get(0));
        var update = "#";

        if (action.includes("NewPuppy")) {
            var groupid = $("#puppygroupid").val();
            update += "puppies" + groupid;
        }
        if (action.includes("NewKennelDog")) {
            update += "kennelDogs";
        }
        if (action.includes("NewCustomerDog")) {
            update += "customerDogs";
        }
        if (action.includes("Register")) {
            update += "AllCustomers";
            action = "/User/Register";
        }

        $.ajax({
            url: action,
            type: 'POST',
            data: formdata,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data.success == undefined) {
                    CloseModal();
                    $(update).html(data);
                    $(thisform)[0].reset();
                }
                else {

                }

            },
            error: function (data) {
                console.log('An error occurred.');
                console.log(data);
            }
        });


    });
    //DELETE MODAL PREPARE 
    $(document).on("click", 'a[data-toggle=modal], button[data-toggle=modal]', function (event) {

        var data_id = '';
        var group_id = '';

        if (typeof $(this).data('id') !== 'undefined') {

            data_id = $(this).data('id');
        }
        if (typeof $(this).data('groupid') !== 'undefined') {

            group_id = $(this).data('groupid');
        }
        var elements = document.querySelectorAll('.This');
        elements.forEach(function (element) {
            element.value = data_id;
        });
        var elements = document.querySelectorAll('.ThisGroup');
        elements.forEach(function (element) {
            element.value = group_id;
        });

    })
    // DELETE MODAL SUBMIT
    $(document).on("submit", ".deleteForm", function (event) {

        event.preventDefault();
        var highlightThis = $(this);
        var action = $(this)[0].name;
        var idToDelete = $(this).children('input[name=id]').val();
        var url = action + "?id=" + idToDelete;
        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                if (action.includes("DeletePuppyGroup")) {
                    CloseModal();
                    $("#puppyGroups").html(data);
                }
                else if (action.includes("DeletePuppy")) {
                    var groupid = $('.ThisGroup').val();
                    var updateId = "#puppies" + groupid;
                    var element = $(updateId);
                    // hittar inte div elementet här
                    CloseModal();

                    $(element).html(data);

                }
                else if (action.includes("DeleteKennelDog")) {
                    CloseModal();

                    $("#kennelDogs").html(data);
                }
                else if (action.includes("DeleteCustomerDog")) {
                    CloseModal();
                    $("#customerDogs").html(data);
                }
                else if (action.includes("DeleteHallBooking")) {
                    CloseModal();
                    $("#customerHallBookings").html(data);
                    $("#AdminHallBookings").html(data);

                }
                else if (action.includes("DeleteHotelBooking")) {
                    CloseModal();
                    $("#customerHotelBookings").html(data);
                    $("#AdminHotelBookings").html(data);
                }
                else if (action.includes("DeleteCustomer")) {
                    CloseModal();
                    $("#AllCustomers").html(data);
                }

            },
            error: function (data) {
                console.log('An error occurred.');
                console.log(data);
            }

        });

    })

    // KENNEL DOG EDITING
    $(document).on("keyup", ".editor", function (event) {

        if (event.keyCode == 13) {
            event.preventDefault();

            var ChangedText = event.currentTarget.textContent;
            // check here
            var updatedCellName = $(this).attr('class').split(' ')[0];


            var a = $(event.currentTarget).siblings('.thedogid');
            var b = a[0].innerHTML;
            $(event.currentTarget).text(ChangedText);
            $(event.currentTarget).blur();

            $.ajax({
                type: 'GET',
                url: '/AdminKennel/EditDog?id=' + b + '&' + updatedCellName + '=' + ChangedText,
                cache: false,
                success: function (result) {
                }
            });
        }

    });


});

// PUPPY GROUP STATUS CHANGED
$(document).on("change", ".puppygroupstatus", function (event) {
    event.preventDefault();

    var id = $(this)[0].id;
    var value = $(this)[0].value;

    //if changed to active prepare and trigger (next) modal
    if (value == 1) {
        var datevalue = $(this).parent('td').prev()[0].innerHTML;
        $("#puppygroupdateofbirth").val(datevalue);
        $("#changedPuppyGroupActiveId").val(id);

        $("#puppyGroupStatusActive").modal();
    }
    else {
        $.ajax({
            type: 'GET',
            url: "ChangePuppyGroupStatus?id=" + id + "&value=" + value,
            cache: false,
            success: CloseModal()
        });
    }

})
// PUPPY GROUP STATUS CHANGED TO ACTIVE
$(document).on("submit", "#ChangePuppyGroupBirthForm", function (event) {
    event.preventDefault();

    var groupid = $("#changedPuppyGroupActiveId").val();
    var newDateOfBirth = $('#puppygroupdateofbirth').val();

    $.ajax({
        type: 'GET',
        url: "/AdminKennel/ChangePuppyGroupStatus?id=" + groupid + "&newBornDate=" + newDateOfBirth,
        cache: false,
        success: function (data) {
            $("#puppyGroups").html(data);
            CloseModal()
        }
    });


})
// NEW PUPPY PREPARE

$(document).on("click", ".addPuppyEvent", function (event) {

    //hämta valpkulls ID att adda valpen till
    var puppyGroupid = $(this).data("groupid");

    $('#puppygroupid').val(puppyGroupid);
    $("#addPuppy").modal();
})

// PUPPY STATUS CHANGED
$(document).on("change", ".puppySold", function (e) {

    var data_id = '';

    if (typeof $(this).data('id') !== 'undefined') {

        data_id = $(this).data('id');
    }

    if (e.target.checked)
        $("#puppyStatus").val(true);
    else
        $("#puppyStatus").val(false);

    $('#puppySoldId').val(data_id);
    $('#confirmPuppySold').modal();

});

// PUPPY EDITING
$(document).on("keyup", ".puppyeditor", function (event) {

    if (event.keyCode == 13) {
        event.preventDefault();

        var ChangedText = event.currentTarget.textContent;


        var a = $(event.currentTarget).siblings('.thepuppyid');
        var b = a[0].innerText;
        $(event.currentTarget).text(ChangedText);
        $(event.currentTarget).blur();

        $.ajax({
            type: 'GET',
            url: '/AdminKennel/EditPuppy?id=' + b + '&name=' + ChangedText,
            cache: false,
            success: function (result) {
            },
            error: function (data) {
                console.log('An error occurred.');
                console.log(data);
            }
        });
    }
    event.preventDefault();

});

// Customers dogs collapse
$(document).on("show.bs.collapse", ".accordian-body", function (event) {
    $(this).closest("table")
        .find(".collapse.in")
        .not(this)
        .collapse('toggle')
})



//Doghotel Book
$(document).ready(function () {

    $("#start_time_1").datetimepicker({
        numberOfMonths: 1,
        dateFormat: "dd-M-yy",
        onSelectDate: function (selected) {
            var dt = new Date(selected);
            dt.setDate(dt.getDate() + 1);
            $("#start_time_2").datetimepicker({
                minDate: dt
            });
        }
    });
    $("#start_time_2").datetimepicker({
        numberOfMonths: 1,
        dateFormat: "dd-M-yy",
        onSelectDate: function (selected) {
            var dt = new Date(selected);
            dt.setDate(dt.getDate() - 1);
            $("#start_time_1").datetimepicker({
                maxDate: dt
            });
        }
    });
})



