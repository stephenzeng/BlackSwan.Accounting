function togglePlusIcon(controlId) {
    if ($(controlId).hasClass('glyphicon-plus')) {
        $(controlId).removeClass('glyphicon-plus').addClass('glyphicon-minus');
    } else {
        $(controlId).removeClass('glyphicon-minus').addClass('glyphicon-plus');
    }
}