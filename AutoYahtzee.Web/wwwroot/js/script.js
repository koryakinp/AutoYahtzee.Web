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
    els[i].innerText = moment(els[i].dataset.timeago).fromNow();
}