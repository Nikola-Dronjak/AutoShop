document.addEventListener('DOMContentLoaded', function () {
    // Initialize the carousel
    var carouselElement = document.getElementById('carImagesCarousel');
    var carouselInstance = new bootstrap.Carousel(carouselElement);

    // Function to remove an image from the carousel
    window.removeImage = function (imageId) {
        // Add the image ID to the hidden input field
        var removedImageIds = document.getElementById('RemovedImageIds');
        var currentIds = removedImageIds.value.split(',').filter(id => id);
        if (!currentIds.includes(imageId)) {
            currentIds.push(imageId);
        }
        removedImageIds.value = currentIds.join(',');

        // Remove the carousel item from the DOM
        var carouselItem = document.querySelector(`.carousel-item[data-image-id="${imageId}"]`);
        if (carouselItem) {
            carouselItem.parentNode.removeChild(carouselItem);

            // Update active state of the remaining carousel items
            var remainingItems = document.querySelectorAll('.carousel-item');
            if (remainingItems.length > 0) {
                remainingItems[0].classList.add('active');
            }
        }

        // Check the number of remaining items
        if (remainingItems.length > 0) {
            carouselElement.style.display = 'block';
            if (carouselInstance) {
                carouselInstance.dispose();
            }
            carouselInstance = new bootstrap.Carousel(carouselElement);
        } else {
            carouselElement.style.display = 'none';
        }
    };
});
