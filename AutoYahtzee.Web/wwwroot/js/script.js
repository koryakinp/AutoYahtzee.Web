Holder.addTheme('thumb', {
    bg: '#55595c',
    fg: '#eceeef',
    text: 'Thumbnail'
});

$(function () {
    $("[data-toggle='tooltip']").tooltip();
});

var els = $('.time-ago-label');

for (var i = 0; i < els.length; i++) {
    els[i].innerText = moment.utc(els[i].dataset.timeago + 'Z').fromNow();
}


var y = [];
var d5 = [];
var d6 = [];
var d7 = [];
var d8 = [];

for (var i = 0; i < 21; i++) {
    y.push(i * 1000);
    d5.push((1 - Math.pow(1 - 1 / Math.pow(6, 4), y[i])) * 100);
    d6.push((1 - Math.pow(1 - 1 / Math.pow(6, 5), y[i])) * 100);
    d7.push((1 - Math.pow(1 - 1 / Math.pow(6, 6), y[i])) * 100);
    d8.push((1 - Math.pow(1 - 1 / Math.pow(6, 7), y[i])) * 100);
}


var chartEL = document.getElementById("probability-chart");
if (chartEL) {
    new Chart(chartEL.getContext('2d'), {
        type: 'line',
        data: {
            labels: y,
            datasets: [
                {
                    data: d5,
                    label: "5 Dice",
                    borderColor: "#3e95cd",
                    fill: false
                }, {
                    data: d6,
                    label: "6 Dice",
                    borderColor: "#8e5ea2",
                    fill: false
                }, {
                    data: d7,
                    label: "7 Dice",
                    borderColor: "#3cba9f",
                    fill: false
                }, {
                    data: d8,
                    label: "8 Dice",
                    borderColor: "#e8c3b9",
                    fill: false
                }
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            tooltips: {
                callbacks: {
                    label: function (tooltipItem, data) {
                        var label = data.datasets[tooltipItem.datasetIndex].label || '';

                        if (label) {
                            label += ': ';
                        }
                        label += tooltipItem.yLabel.toFixed(2);
                        return label;
                    }
                }
            },
            title: {
                display: true,
                text: 'Probability of rolling a Yahtzee'
            },
            scales: {
                xAxes: [{
                    scaleLabel: {
                        display: true,
                        labelString: 'Numer of rolls'
                    }
                }],
                yAxes: [{
                    scaleLabel: {
                        display: true,
                        labelString: 'Probability'
                    }
                }]
            }
        }
    });
}

toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-bottom-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

if (document.getElementById('contact-form')) {
    if (contactFormResponse == 'SUCCESS') {
        toastr.success('Thank you for contacting me', 'Thank you!')
    } else if (contactFormResponse == 'FAIL') {
        toastr.error('An error occured. Try again later.', 'An error occured')
    }
}

if (document.getElementById('prediction-wrapper')) {
    var wrapperWidth = parseInt(getComputedStyle(document.getElementById("prediction-wrapper")).width);
    var numberOfImages = document.getElementsByClassName('prediction-image').length;

    if (wrapperWidth < numberOfImages * 50) {
        var targetImageWidth = Math.round((wrapperWidth / numberOfImages) - (numberOfImages - 1) * 2);

        var images = document.getElementsByClassName('prediction-image');

        for (var i = 0; i < images.length; i++) {
            images[i].style.width = targetImageWidth + 'px';
            images[i].style.height = targetImageWidth + 'px';
        }
    }
}


