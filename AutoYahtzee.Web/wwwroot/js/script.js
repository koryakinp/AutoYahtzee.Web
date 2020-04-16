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

for (var i = 0; i < 20; i++) {
    y.push(i * 1000);
    d5.push((1 - Math.pow(1 - 1 / Math.pow(6, 4), y[i])) * 100);
    d6.push((1 - Math.pow(1 - 1 / Math.pow(6, 5), y[i])) * 100);
    d7.push((1 - Math.pow(1 - 1 / Math.pow(6, 6), y[i])) * 100);
    d8.push((1 - Math.pow(1 - 1 / Math.pow(6, 7), y[i])) * 100);
}


new Chart(document.getElementById("probability-chart"), {
    type: 'line',
    data: {
        labels: y,
        datasets: [
            {
                data: d5,
                label: "5 Dices",
                borderColor: "#3e95cd",
                fill: false
            }, {
                data: d6,
                label: "6 Dices",
                borderColor: "#8e5ea2",
                fill: false
            }, {
                data: d7,
                label: "7 Dices",
                borderColor: "#3cba9f",
                fill: false
            }, {
                data: d8,
                label: "8 Dices",
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
        }
    }
});