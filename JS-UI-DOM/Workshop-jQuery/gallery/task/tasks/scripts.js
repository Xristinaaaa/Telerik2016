/* globals $ */

function solve() {
$.fn.gallery = function (columns) {
  columns = columns || 4;

  var $gallery = this;
  $gallery.addClass('gallery');

  var $galleryList = $gallery.children('.gallery-list');
  var $selected = $gallery.children('.selected');
  var $imageContainers = $galleryList.children('.image-container');
  var $currentImage = $selected.find('#current-image');
  var $previousImage = $selected.find('#previous-image');
  var $nextImage = $selected.find('#next-image');

  $selected.hide();

  $imageContainers.each(function (index, element) {
    if (index % columns === 0) {
      $(element).addClass('clearfix');
    }
  });

  $galleryList.on('click', 'img', function () {
    var $this = $(this);
    $galleryList.addClass('blurred');
    $('<div />').addClass('disabled-background').appendTo($this);
    applySelected($this);
    $selected.show();
  });

  function applySelected($element){
    var currentImageInfo = getImageInformation($element);
    setImageInfo($currentImage, currentImageInfo.src, currentImageInfo.index);
    var previousIndex=getPreviousIndex(currentImageInfo.index);
    var nextIndex=getNextIndex(currentImageInfo.index);
    var previousImage=getImageByIndex(previousIndex);
    var nextImage=getImageByIndex(nextIndex);
    var previousImageInfo=getImageInformation(previousImage);
    var nextImageInfo=getImageInformation(nextImage);
    setImageInfo($previousImage, previousImageInfo.src, previousImageInfo.index);
    setImageInfo($nextImage, nextImageInfo.src, nextImageInfo.index);
  }

  $currentImage.on('click', function () {
    $galleryList.removeClass('blurred');
    $selected.hide();
    $gallery.children('disabled-background').remove();
  });

  $previousImage.on('click', function(){
    var $this= $(this);
    applySelected($this);
  });

  $nextImage.on('click', function(){
    var $this= $(this);
    applySelected($this);
  });

  function getImageByIndex(index) {
    return $gallery.find('img[data-info="' + index + '"]');
  }
  function getImageInformation($element) {
    return {
      src: $element.attr('src'),
      index: parseInt($element.attr('data-info'))
    };
  }

  function setImageInfo($element, src, index) {
    $element.attr('src', src);
    $element.attr('data-info', index);
  }

  function getNextIndex(index) {
    index++;
    if (index > $imageContainers.length) {
      index = 1;
    }
    return index;
  }
  function getPreviousIndex(index) {
    index--;
    if (index < 1) {
      index = $imageContainers.length;
    }
    return index;
  }
  return this;
};
}
module.exports = solve;