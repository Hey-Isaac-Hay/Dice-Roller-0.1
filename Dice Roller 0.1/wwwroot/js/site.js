// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function fourDropLowest() {
    //rolls stats for you and automatically drops the lowest number
    let low = 9999;
    let hold, sum;

    //generates the stats
    for (let i = 0; i < 4; i++) {
        hold = Math.floor(Math.random() * 6) + 1;

        sum += hold;

        //finds the lowest and stores the value
        if (hold < low)
            low = hold;
    }

    //drops the lowest
    sum -= low;

    return sum;
}

function bruh() {
    return "hello";
}