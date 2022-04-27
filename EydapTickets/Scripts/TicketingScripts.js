function OnFocusNumericControl(aControl, aLength) {

    var lPrevVal = $(aControl).attr('maxlength');

    if (lPrevVal != aLength + 1)
    {
        $(aControl).attr('maxlength', aLength + 1);
    }    
};

function OnKeyDownNumericControl(event, aControl, aLength, aDecimals) {
        
    //event.preventDefault();
    //alert(event.type);    

    if (event.keyCode != 8 && event.keyCode != 46 && event.keyCode != 9 && event.keyCode != 38 && event.keyCode != 40 && event.keyCode != 39
        && event.keyCode != 37)// && event.key != ',' && event.key != '.')
    {
        var lCurVal = event.key; //$(aControl).val();

        //if (!IsLocaleNumeric(lCurVal) || !IsValidNumber(aControl.val().toString() + lCurVal.toString(), aLength, aDecimals)) {
        if (!IsValidNumber(aControl.val().toString() + lCurVal.toString(), aLength, aDecimals)) {
            event.preventDefault();
        }
    }      
};

function OnKeyUpNumericControl(event, aControl) {

    //event.preventDefault();
    //alert(event.type);    

    var lCurVal = $(aControl).val();
    var lPrevVal = $(aControl).attr('prevval');

    if (IsLocaleNumeric(lCurVal)) {
        $(aControl).attr('prevval', lCurVal.toString());
    }
    else if(lPrevVal && lCurVal && lCurVal.toString().length > 0){
        $(aControl).val(lPrevVal);
    }
    else if (!lCurVal || lCurVal.toString().length == 0) {
        $(aControl).attr('prevval', "");
    }
};

function OnValueChangedNumericControl(event, aControl) {

    //event.preventDefault();
    //alert(event.type);    

    var lCurVal = $(aControl).val();

    if (!IsLocaleNumeric(lCurVal))
    {
        $(aControl).val(0);
    }
    else {
        var num = 0.1;
        var decimalSeparator = num.toLocaleString().replace(/\d/g, '');
        $(aControl).val(lCurVal.replace('.', decimalSeparator));        
    }
};

function countDecimalPlaces(number) {
    number = number.toString();

    var lDecPlace = 0;

    if (number.indexOf('.') > 0)
    {
        lDecPlace = number.length - (number.indexOf('.') + 1);
    }
    else if (number.indexOf(',') > 0) {
        lDecPlace = number.length - (number.indexOf(',') + 1);
    }

    return lDecPlace;
}

function IsLocaleNumeric(aValue)
{
    return $.isNumeric((aValue.replace(',', '.') * 1));
}

function IsValidNumber(aValue, aLength, aDecimals)
{
    if (IsLocaleNumeric(aValue)) {
        var lVal = aValue.replace(',', '.');
        var lIntEndIndex = lVal.indexOf('.');
        var lIntPartMaxLength = aLength - aDecimals;

        if (lIntEndIndex == -1 && aValue.length <= lIntPartMaxLength) {
            return true;
        }

        if (lIntEndIndex <= lIntPartMaxLength) {
            var lDecPart = aValue.length - (lIntEndIndex + 1);

            if (lDecPart <= aDecimals) {
                return true;
            }
            else {
                return false;
            }            
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }
}

function debug() {
    debugger;
}