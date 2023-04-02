function moveCarousel(direction) {
    let el = document.querySelector('.carousel');
    if (direction == 'left') {
        el.scrollBy({
            top: 0,
            left: -350,
            behavior: 'smooth'
        });
    }
    else {
        el.scrollBy({
            top: 0,
            left: +350,
            behavior: 'smooth'
        })
    }
}