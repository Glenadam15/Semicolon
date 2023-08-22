
$(function () {
	var SlideElement = $(".AllSlideArea");
	var SlideCreateElement = SlideElement.find(".SlideAreaImg");
	var SlideListLenght = SlideCreateElement.find(".SlideImg").length;
	var DocumentLenghtForSlide = SlideElement.outerWidth();
	var AllLenght = SlideListLenght * DocumentLenghtForSlide;
	var ImgOrder = 0;
	var SlideArea = 0;

	SlideCreateElement.find(".SlideImg").width(DocumentLenghtForSlide).end().width(AllLenght);

	$(window).resize(function () {
		SlideElement = $(".AllSlideArea");
		SlideCreateElement = SlideElement.find(".SlideAreaImg");
		SlideListLenght = SlideCreateElement.find(".SlideImg").length;
		DocumentLenghtForSlide = SlideElement.outerWidth();
		AllLenght = SlideListLenght * DocumentLenghtForSlide;

		SlideCreateElement.find(".SlideImg").width(DocumentLenghtForSlide).end().width(AllLenght).css("margin-left", "-" + (ImgOrder * DocumentLenghtForSlide) + "px");
	});

	$.AutoSlideChange = function () {
		if (ImgOrder < SlideListLenght - 1) {
			ImgOrder++;
			SlideArea = "-" + (ImgOrder * DocumentLenghtForSlide) + "px";
		} else {
			ImgOrder = 0;
			SlideArea = 0;
		}

		SlideCreateElement.stop().animate({
			marginLeft: SlideArea
		}, 500, function () {
			SlideElement = $(".AllSlideArea");
			SlideCreateElement = SlideElement.find(".SlideAreaImg");
			SlideListLenght = SlideCreateElement.find(".SlideImg").length;
			DocumentLenghtForSlide = SlideElement.outerWidth();
			AllLenght = SlideListLenght * DocumentLenghtForSlide;

			SlideCreateElement.find(".SlideImg").width(DocumentLenghtForSlide).end().width(AllLenght).css("margin-left", "-" + (ImgOrder * DocumentLenghtForSlide) + "px");
		});
	}

	var SlaytOynat = setInterval("$.AutoSlideChange()", 7000);
});
	