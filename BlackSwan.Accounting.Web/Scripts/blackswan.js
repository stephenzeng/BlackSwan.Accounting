function toggleDisplay(divId, control) {
    if ($(divId).hasClass('hide')) {
        $(divId).removeClass('hide');
        $(control).removeClass('glyphicon-plus').addClass('glyphicon-minus');
    } else {
        $(divId).addClass('hide');
        $(control).removeClass('glyphicon-minus').addClass('glyphicon-plus');
    }
}