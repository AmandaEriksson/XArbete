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
    // New form (puppy, kenneldog, puppygroup, customer, admin, customerdog)
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

    // KENNEL DOG & PUPPY EDITING
    $(document).on("keyup", ".editor", function (event) {

        if (event.keyCode == 13) {
            event.preventDefault();

            var ChangedText = event.currentTarget.textContent;
            // check here
            var updatedCellName = $(this).attr('class').split(' ')[0];
            console.log(updatedCellName)

            var a = $(event.currentTarget).siblings('.thedogid');
            var b = a[0].innerHTML;
            $(event.currentTarget).text(ChangedText);
            $(event.currentTarget).fadeOut().fadeIn().blur();

            var url = '/AdminKennel/EditDog?id=' + b + '&' + updatedCellName + '=' + ChangedText;
            if (updatedCellName == "puppy") {
                url = '/AdminKennel/EditPuppy?id=' + b + '&name=' + ChangedText
            }



            $.ajax({
                type: 'GET',
                url: url,
                cache: false,
                success: function (result) {
                }
            });
        }

    });


});

// NEW PUPPY PREPARE

$(document).on("click", ".addPuppyEvent", function (event) {

    //hämta valpkulls ID att adda valpen till
    var puppyGroupid = $(this).data("groupid");

    $('#puppygroupid').val(puppyGroupid);
    $("#addPuppy").modal();
})

// group status changed, prepare and open confirm modal
$(document).on("change", ".puppygroupstatus", function (e) {


    var id = $(this)[0].id;
    var status = $(this)[0].value;
    var datevalue = $(this).parent('td').prev()[0].innerHTML;
    $("#previousBirthOfDate").val(datevalue);
    $('#relevantStatusId').val(id);
    $("#changedStatus").val(status);

    $("#puppygroupdateofbirth").val(datevalue);
    $("#changedPuppyGroupActiveId").val(id);

    $("#confirmStatus").modal();
});


// puppy status changed, prepare and open confirm modal
$(document).on("change", ".puppySold", function (e) {

    var data_id = '';

    if (typeof $(this).data('id') !== 'undefined') {

        data_id = $(this).data('id');
    }

    $("#changedStatus").val(e.target.checked);
    $("#IfChangedPuppyStatus").val(true);
    $('#relevantStatusId').val(data_id);
    $('#confirmStatus').modal();
});

//after confirmed (puppy AND group), open changebirth modal if status's active
$(document).on("submit", ".changedStatusForm", function () {
    event.preventDefault();

    var status = $("#changedStatus").val();
    if (status == 1) {
        $("#puppyGroupStatusActive").modal();
    }
    else {
        var action = "ChangePuppyGroupStatus";
        var a = $("#IfChangedPuppyStatus").val();
        if ($("#IfChangedPuppyStatus").val() == 'true') {
            action = "ChangePuppyStatus";
        }

        var id = $('#relevantStatusId').val();
        $.ajax({
            type: 'GET',
            url: action + "?id=" + id + "&status=" + status,
            cache: false,
            success: function (data) {
                if (action != "ChangePuppyStatus") {
                    $("#puppyGroups").html(data);
                }
                CloseModal();
            }

        });

    }

})
// if status changed to Active on group
$(document).on("submit", "#ChangePuppyGroupBirthForm", function () {
    event.preventDefault();
    var id = $("#changedPuppyGroupActiveId").val();
    var newbornDate = $("#puppygroupdateofbirth").val();

    $.ajax({
        type: 'GET',
        url: "ChangePuppyGroupStatus?id=" + id + "&newBornDate=" + newbornDate,
        cache: false,
        success: function (data) {
                $("#puppyGroups").html(data);
            
            CloseModal();
        }

    });
})

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
        minDate: 0,
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

// MANAGE BOOKINGS
// bind archived bookings
$(document).bind("click", ".oldBookings", function (event) {

    $(this).closest('table').children('.tog').toggle();
});


// booking payed PREPARE
$(document).on("change", ".bookingPayed", function (event) {
    event.preventDefault();

    if (event.target.checked) {

        var data_id = '';

        if (typeof $(this).data('id') !== 'undefined') {

            data_id = $(this).data('id');
        }

        $('#PayedBookingId').val(data_id);

        $('#confirmPayedBooking').modal();

    }
});

// booking payed SUBMIT

$(document).on("submit", "#bookingConfirmPaymentForm", function (event) {
    event.preventDefault();
    $(".loadingIcon").addClass("fas fa-spinner fa-spin");
    var id = $('#PayedBookingId').val();

    $.ajax({
        type: 'GET',
        url: '/AdminCustomers/ConfirmPayment?id=' + id,
        cache: false,
        success: function (result) {
            CloseModal();
            $(".loadingIcon").removeClass("fas fa-spinner fa-spin");

        },
        error: function (data) {
            console.log('An error occurred.');
            console.log(data);
        }
    });
})

$(document).on("submit", "#hotelBookingModal", function () {
    $("#loadingIcon").addClass("fas fa-spinner fa-spin");
})


// Customers

$(document).on("submit", "#EditCustomerForm", function (event) {
    event.preventDefault();
    var formdata = new FormData($(this).get(0));

    $.ajax({
        url: '/Customer/Edit',
        type: 'POST',
        data: formdata,
        processData: false,
        contentType: false,
        success: function (data) {
            $('#customerEdit').html(data);


        },
        error: function (data) {
            console.log('An error occurred.');
            console.log(data);
        }
    });
});

$(document).ready(function (event) {
    if (window.location.pathname == "/Customer") {

        // KOLLA OM FUNKAR
        let dropdown = $('.breed-dropdown');

        dropdown.empty();

        dropdown.append('<option selected="false" value="Blandras">Blandras</option>');
        dropdown.prop('selectedIndex', 0);

        const url = 'https://dog.ceo/api/breeds/list/all';
        var breedsArray = [];
        // Populate dropdown with list of provinces
        $.getJSON(url, function (data) {
            $.each(data["message"], function (key, entry) {

                if (entry.length == 0) {
                    var capitalizedFirstLetter = key[0].toUpperCase() + key.slice(1);
                    breedsArray.push(capitalizedFirstLetter);
                }
                else {
                    for (i = 0; i < entry.length; i++) {
                        var en = entry[i];
                        var capitalizedEntry = en[0].toUpperCase() + en.slice(1);
                        var capitalizedKey = key[0].toUpperCase() + key.slice(1);
                        breedsArray.push(capitalizedEntry + ' ' + capitalizedKey)
                    }
                }
            })
            var sortedArray = breedsArray.sort()
            for (var i = 0; i < sortedArray.length; i++) {
                dropdown.append($('<option></option>').attr('value', sortedArray[i]).text(sortedArray[i]));
            }

        })

    }

})


// admin customer search

$(document).on("keyup", "#AdminSearchCustomer", function (event) {
    event.preventDefault();
    var searchValue = $(this).val();
    $.ajax({
        type: 'GET',
        url: '/AdminCustomers/Search?searchValue=' + searchValue,
        cache: false,
        success: function (data) {
            $("#AllCustomers").html(data);

        },
        error: function (data) {
            console.log('An error occurred.');
            console.log(data);
        }
    });
})


// kennel content functionality


    $(document).on("click", ".deleteKennelSection", function (event) {
        event.preventDefault();
        var sectionId = $(this).data("id");
        var sectionBreedId = $(this).data("breedid");

        var update = "#breedSections" + sectionBreedId;
        $.ajax({
            type: 'GET',
            url: '/AdminContent/DeleteContentSection?id=' + sectionId,
            cache: false,
            success: function (data) {
                $(update).html(data);
            },
            error: function (data) {
                console.log('An error occurred.');
                console.log(data);
            }
        });
    })

    // add section submit
    $(document).on("submit", ".newKennelContentSectionForm", function (event) {

        event.preventDefault();
        var thisform = $(this);
        var breedId = $(this).children(".newSectionBreedId").val();
        var title = $(this).find("input[name=Title]").val();
        var text = $(this).find("input[name=Section]").val();

        var update = '#breedSections' + breedId

        $.ajax({
            type: 'GET',
            url: '/AdminContent/NewContentSection?id=' + breedId + '&title=' + title + '&text=' + text,
            cache: false,
            success: function (data) {
                $(update).html(data);

                $(thisform)[0].reset();
                CloseModal();
            },
            error: function (data) {
                console.log('An error occurred.');
                console.log(data);
            }
        });


    });
    $(document).on("keyup", ".breedEditing", function (event) {

        if (event.keyCode == 13 || event.currentTarget.id == "formfile") {
            event.preventDefault();
            var event = event.currentTarget;
            var ChangedText = event.value;

            var updatedCellName = event.name;

            var a = $(event).siblings('.breedId');
            var breedid = a[0].value;




            $.ajax({
                type: 'GET',
                url: '/AdminContent/EditContent?id=' + breedid + '&' + updatedCellName + '=' + ChangedText,
                cache: false,
                success: function (result) {
                    $(event).text(ChangedText);
                    //$(event).blur();
                    //$(event).addClass("fas fa-spinner fa-spin");
                    $(event).fadeOut().fadeIn().blur();

                }
            });
        }

    });

    $(document).on("change", ".breedFileEditingForm", function (event) {

        event.preventDefault();

        var form = $(this).parent("form");
        var formdata = new FormData($(form).get(0));

        var imgToUpdate = $(this).siblings(".breedImage");

        $.ajax({
            url: '/AdminContent/EditContent',
            type: 'POST',
            data: formdata,
            processData: false,
            contentType: false,
            success: function (data) {
                var imgsrc = "/img/breeds/" + data.data;
                imgToUpdate.attr("src", imgsrc);
                imgToUpdate.show();


            },
            error: function (data) {
                console.log('An error occurred.');
                console.log(data);
            }
        });



    });
