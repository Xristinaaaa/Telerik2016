function solve() {
$.fn.datepicker = function () {
    var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'Septembre', 'Octobre', 'Novembre', 'Decembre'];
    var days = ['Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa', 'Su'];

    //Date.prototype        
    Date.prototype.getNextYear = function () {
        return new Date(this.getFullYear() + 1, 0, 1);
    };
    Date.prototype.getPreviousYear = function () {
        return new Date(this.getFullYear() - 1, 11, 31);
    };

    Data.prototype.getMonthName = function () {
        return months[this.getMonth()];
    };
    Data.prototype.getPreviousMonthName = function () {
        if (this.getMonth() > 0) {
            return new Date(this.getFullYear(), this.getMonth() - 1, daysInMonth(this.getFullYear(), this.getMonth()));
        } else {
            return this.getPreviousYear();
        }
    };
    Data.prototype.getNextMonthName = function () {
        if (this.getMonth() < 11) {
            return new Date(this.getFullYear(), this.getMonth() + 1, 1);
        } else {
            return this.getNextYear();
        }
    };

    Data.prototype.getDayName = function () {
        return days[this.getDay()];
    };
    Data.prototype.getPreviousDayName = function () {
        if (this.getDate() > 1) {
            return new Date(this.getFullYear(), this.getMonth(), this.getDate() - 1);
        } else {
            return this.getPreviousMonth();
        }
    };
    Data.prototype.getNextDayName = function () {
        if (this.getDate() < daysInMonth(this.getFullYear(), this.getMonth() + 1)) {
            return new Date(this.getFullYear(), this.getMonth(), this.getDate() + 1);
        } else if (this.getDate() === daysInMonth(this.getFullYear(), this.getUTCMonth() + 1)) {
            return this.getNextMonth();
        }
    };

    function daysInMonth(year, month) {
        return new Date(year, month, 0).getDate();
    }

    //Logic
    var date = new Date();
    var $inputDate = $(this).addClass('datepicker');
    var $datePickerWrapper = $('<div />').addClass('datepicker-wrapper');
    $inputDate.wrap($datePickerWrapper);

    var $picker = $('<div />').addClass('picker');

    var $controls = $('<div />').addClass('controls');
    var $previousMonth = $('<button />').addClass('btn').addClass('left');
    $previousMonth.text('<');
    var $currentMonth = $('<div />').addClass('current-month');
    $currentMonth.text(months[date.getMonthName()] + ' ' + date.getFullYear());
    var $nextMonth = $('<button />').addClass('btn').addClass('right');
    $nextMonth.text('>');
    $controls.append($previousMonth);
    $controls.append($currentMonth);
    $controls.append($nextMonth);

    var $calendar = $('<table />').addClass('calendar');
    createCalendar(date.getFullYear(), date.getMonthName());

    var $currentDate = $('<div />').addClass('current-date');
    var $currentDateText = $('<div />').addClass('current-date-link');
    $currentDateText.text(new Date().getDate() + ' ' + months[new Date().getMonthName()] + new Date.getFullYear());
    $currentDateText.appendTo($currentDate);

    $picker.append($controls);
    $picker.append($calendar);
    $picker.append(currentDate);

    $datePickerWrapper.append($picker);
    
    function createCalendar(year, month) {
        $calendar.html('');
        var dateNow = new Date(year, month, 1);
        do {
            dateNow = dateNow.getPreviousDayName();
        } while (dateNow.getDayName() !== days[0]);

        //set week names
        var $th;
        var $td;
        var $tr = $('<tr />');

        for (var i = 0; i < 7; i += 1) {
            $th = $('<th />').text(days[i]);
            $th.appendTo($tr);
        }
        $tr.appendTo($calendar);

        //set days
        for (var j = 0; j < 6; j += 1) {
            $tr = $('<tr />');

            for (var k = 0; k < 7; k += 1) {
                $td = $('<td />').text(dateNow.getDate());

                if (dateNow.getMonthName() !== month) {
                    $td.addClass('another-month');
                } else {
                    $td.addClass('current-month');
                }

                $td.attr('data-info', dateNow.getDate() + '/' + (dateNow.getMonthName() + 1) + '/' + dateNow.getFullYear());

                $td.appendTo($tr);

                dateNow = dateNow.getNextDayName();
            }

            $tr.appendTo($calendar);
        }
    }

    //Events

    $('.picker').on('click', function () {
        $picker.addClass('picker-visible');
    });

    $('.left').on('click', function () {
        date = date.getPreviousMonthName();
        createCalendar(date.getFullYear(), date.getMonthName());
        $currentMonth.text(months[date.getMonthName()] + ' ' + date.getFullYear());
    });
    $('.right').on('click', function () {
        date = date.getNextMonthName();
        createCalendar(date.getFullYear(), date.getMonthName());
        $currentMonth.text(months[date.getMonthName()] + ' ' + date.getFullYear());
    });

    date.select(function () {
        //close calendar and fill input with correct date
    });

     $('.current-date-link').on('click', function () {      
        date = date.getNextMonthName();
        $inputDate.val(new Date().getDate() + '/' + (new Date().getMonthName() + 1) + '/' + new Date().getFullYear());
        $picker.removeClass('picker-visible');
    });

    //initially when onfocus should show the calendar 
    //hide the calendar if click outside the datepicker control

    return this;
};
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}