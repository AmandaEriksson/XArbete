$(function () {
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
});