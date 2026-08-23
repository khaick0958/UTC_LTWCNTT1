let currentSlide = 0;

const slides = document.querySelectorAll(".Slide");
const dots = document.querySelectorAll(".Dot");

function showSlide(index) {

    if (index >= slides.length) {
        currentSlide = 0;
    }
    else if (index < 0) {
        currentSlide = slides.length - 1;
    }
    else {
        currentSlide = index;
    }

    // Xóa active khỏi tất cả slide
    slides.forEach(slide => {
        slide.classList.remove("active");
    });

    // Xóa active khỏi tất cả dot
    dots.forEach(dot => {
        dot.classList.remove("active");
    });

    // Active slide hiện tại
    slides[currentSlide].classList.add("active");

    // Active dot hiện tại
    dots[currentSlide].classList.add("active");
}


function changeSlide(direction) {
    showSlide(currentSlide + direction);
}


function goToSlide(index) {
    showSlide(index);
}


/*
 * Tự động chuyển slide
 * 5000 = 5 giây
 */
setInterval(() => {
    changeSlide(1);
}, 5000);