var date = document.getElementById('cc-expiration');

// This function checks the value of the input and returns a string with the correct format for the date (MM / YY)
function checkValue(str, max) {
    if (str.charAt(0) !== '0' || str == '00') {
        var num = parseInt(str);
        if (isNaN(num) || num <= 0 || num > max) num = 1;
        str = num > parseInt(max.toString().charAt(0)) && num.toString().length == 1 ? '0' + num : num.toString();
    }
    return str;
}

// This event listener is triggered when the user types in the input field
date.addEventListener('input', function(e) {
    this.type = 'text';
    var input = this.value;
    if (/\D\/$/.test(input)) input = input.substr(0, input.length - 3);
    var values = input.split('/').map(function(v) {
        return v.replace(/\D/g, '')
    })
    if (values[0]) values[0] = checkValue(values[0], 12); // Change here to accept up to 12 for the month
    if (values[1]) values[1] = checkValue(values[1], 99); // Change here to accept up to 99 for the year
    var output = values.map(function(v, i) {
        return v.length == 2 && i < 1 ? v + ' / ' : v; // Change here to only add the slash after the month
    })
    this.value = output.join('').substr(0, 7); // Change here to limit the output to 7 characters (MM / YY)
})

date.addEventListener('blur', function(e) {
    this.type = 'text';
    var input = this.value;
    var values = input.split('/').map(function(v, i) {
        return v.replace(/\D/g, '')
    });
    var output = '';

    if (values.length == 2) {
        var year = values[1].length !== 2 ? parseInt(values[1]) + 2000 : parseInt(values[1]);
        var month = parseInt(values[0]) - 1;
        var d = new Date(year, month);
        if (!isNaN(d)) {
            document.getElementById('result').innerText = d.toString();
            var dates = [d.getMonth() + 1, d.getFullYear()];
            output = dates.map(function(v) {
                v = v.toString();
                return v.length == 1 ? '0' + v : v;
            }).join(' / ');
        }
    }
    this.value = output;
})