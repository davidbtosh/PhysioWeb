
//var $range = $("#ionrange");
//var answer;
var answer = 0;
//var $range = $("#ir-slider");
//var slider;

var create_slider = function (postfix) {

    $("#ir-slider").ionRangeSlider({
        min: 1,
        max: 10,
        from: 1,
        max_postfix: postfix,
        onFinish: function (slider_data) {
            answer = slider_data.from;
        }
    });

//    slider = $range.data("ionRangeSlider");
}

//var create_slider = function () {

//    var slider = document.getElementById('noui-slider');

//    noUiSlider.create(slider, {
//        start: [1],
//        range: {
//            'min': [1],
//            'max': [10]
//        }
//    });
//}

//var reset_slider = function () {

//    $("#noui-slider").remove();
//    $("#slider-container").append("<div id='noui-slider'></div>")
//    create_slider();
//}

var reset_slider = function () {
    
    $("#slider-container-inner").remove();
    $("#slider-container-outer").append("<div id='slider-container-inner'><div id='ir-slider'></div></div>")
    //create_slider();
}

//var get_slider_value = function () {

//    var slider = document.getElementById('noui-slider');
//    answer = slider.noUiSlider.get();
//    return answer;
//}

var get_slider_value = function () {
    return answer;
}

//var destroy_slider = function () {
    
//    slider && slider.destroy();
//}

//var reset_slider = function () {
//    var sd = $("#ir-slider");

//}

$(document).ready(function () {

    //$('.animation_select').click(function () {
    //    $('#animation_box').removeAttr('class').attr('class', '');
    //    var animation = $(this).attr("data-animation");
    //    $('#animation_box').addClass('animated');
    //    $('#animation_box').addClass(animation);
    //    return false;
    //});
    //var answer = 0;
   
    //create_slider();

    GetQuestionnaire();
});


function GetQuestionnaire() {

    var params = '&patientId=1';

    $.ajax({
        url: TakeQuestionnaireUrl,
        data:params,
        cache: false,
        type: 'GET',
        contentType: "application/json;charset=utf-8",
        dataType: 'json',
        success: function (result) {

            var viewModel = new QuestionSetViewModel(result);
            create_slider(viewModel.CurrentQuestion().UIcaption());
            ko.applyBindings(viewModel);
        },
        error: function (errorThrown) {
            var errorMsg = errorThrown;
        }
    });
}


function QuestionSetViewModel(result) {

    //Make the self as 'this' reference
    var self = this;

    self.QuestionIndex = ko.observable(0);

    self.QuestionNumber  = ko.computed(function () {
        return self.QuestionIndex() + 1;
    });

    self.QuestionSet = ko.observableArray([]); // Contains the list of QuestionItems

    var mappedQuestions = $.map(result.questSet, function (item) { return new QuestionViewModel(item) });

    self.QuestionSet(mappedQuestions);

    //self.CurrentQuestion = ko.observable(self.QuestionSet()[self.CurrentIndex()]);

    self.CurrentQuestion = ko.computed(function () {
        return self.QuestionSet()[self.QuestionIndex()]
    });


    //self.CurrentAnswer = ko.computed(function () {
    //    return self.QuestionSet()[self.QuestionIndex()].Answer;
    //});

    //self.CurrentUi = ko.computed(function () {
    //    return self.QuestionSet()[self.QuestionIndex()].Answer;
    //});

    //self.CurrentQuestion().CreateSlider();

    self.SubmitQuestion = function (item, event) {

       
       // self.Validate();

        var jsonString = ko.toJSON(item);

        var jsonObj = JSON.parse(jsonString);

        //get answer from slider.
        answer = get_slider_value();
        //answer = 7;
        

        jsonObj.Answer = answer;

        var updatedItem = JSON.stringify(jsonObj);

        $.ajax({
            url: SaveAnswerUrl,
            type: 'POST',
            cache: false,
            contentType: "application/json;charset=utf-8",
            dataType: 'json',
            data: updatedItem,
            success: function (result) {
           
                if (self.QuestionNumber() < self.QuestionSet().length) {
                    self.QuestionIndex(self.QuestionNumber());


                    var animation = $('#animation_area').attr('class');
                    if (animation.indexOf('bounceInLeft') > -1) {
                        animation = 'animated bounceInRight';
                    }
                    else {
                        animation = 'animated bounceInLeft';
                    }

                    $('#animation_area').removeAttr('class').attr('class', '');

                    $('#animation_area').addClass(animation);
                    //$('#animation_box').animateCss('bounceInLeft');



                }
                else {

                    //swal({
                    //    title: "Questionnaire complete!",
                    //    text: "Now you can look at your results.",
                    //    type: "success"
                    //});

                   
                    swal({
                        title: "Questionnaire complete!",
                        text: "Now you can look at your results!",
                        type: "success",
                        showCancelButton: true,
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "Go to Results",
                        cancelButtonText: "Take another questionnaire!",
                        closeOnConfirm: false,
                        closeOnCancel: false
                    },
                            function (isConfirm) {
                                if (isConfirm) {
                                    window.location.href = '/Patient/PatientChart';
                                } else {
                                    window.location.href = '/Question/Index';
                                }
                            });
                }

                //var uiCaption = self.CurrentQuestion().UIcaption();

                //reset slider
                //answer = 1;
                //var slider = document.getElementById('noui-slider');
                //slider.noUiSlider.set(answer);
                //destroy_slider();

                reset_slider();
                create_slider(self.CurrentQuestion().UIcaption());

                //var slider = $("#ionrange").data("ionRangeSlider");

                //// Call sliders update method with any params
                //slider.update({
                //    from: 1,
                //});
            
                //self.CurrentQuestion().CreateSlider();
                
                //UpdateSlider(uiCaption);
           
            }
        })
        .fail();
        //function (xhr, textStatus, err) {
        //    alert(err);
        //});

    }

    //self.resetSlider = function () {
       
    //    //var $range = $("#ionrange");
    //    //var slider = $range.data("ionRangeSlider");

    //    var slider = $("#ionrange").data("ionRangeSlider");

    //    // Call sliders reset method
    //    slider.reset();

    //}

    //self.updateSlider = function () {
       
    //    //var $range = $("#ionrange");
    //    //var slider = $range.data("ionRangeSlider");

    //    var slider = $("#ionrange").data("ionRangeSlider");

    //    slider.update({ from: 0, max_postfix: self.CurrentQuestion().UIcaption() });
       

    //}

    //});

   



}


function QuestionViewModel(item) {

    //Make the self as 'this' reference
    var self = this;

    self.PatientId = ko.observable(item.PatientId);

    self.PatientName = ko.observable(item.PatientName);

    self.PatientQuestionnaireId = ko.observable(item.PatientQuestionnaireId);

    self.QuestionSetId = ko.observable(item.QuestionSetId);

    self.QuestionnaireDate = ko.observable(item.QuestionnaireDate);

    self.QuestionId = ko.observable(item.QuestionId);

    self.QuestionSetName = ko.observable(item.QuestionSetName);

    self.QuestionText = ko.observable(item.QuestionText);

    self.QuestionHint = ko.observable(item.QuestionHint);

    self.QuestionAbbreviation = ko.observable(item.QuestionAbbreviation);

    self.Answer = ko.observable(item.Answer);

    self.UIcaption = ko.observable(item.UIcaption);

    //self.ResetSlider = function () {
        
    //    $("#ionrange").ionRangeSlider({
    //        min: 1,
    //        max: 10,
    //        from: 1,
    //        max_postfix: self.UIcaption(),
    //        onFinish: function (slider_data) {
    //            self.Answer(slider_data.from);
    //        }
    //    });

    //    var sld = $("#ionrange").data("ionRangeSlider");

    //    sld.reset();

    //    //var slider = $range.data("ionRangeSlider");
    //    //slider.reset();

    //}
    
    //self.CreateSlider = function () {
                
    //    $range.ionRangeSlider({
    //        min: 1,
    //        max: 10,
    //        from: 1,
    //        max_postfix: self.UIcaption(),
    //        onFinish: function (slider_data) {
    //            self.Answer(slider_data.from);
    //        }
    //    });

    //    slider = $range.data("ionRangeSlider");
    //}

    
}



//function CreateSlider (UICaption) {

//    //var $range = $("#ionrange");
//    //var slider = $range.data("ionRangeSlider");

//    var slider = $("#ionrange").data("ionRangeSlider");

//    slider.update({ from: 0, max_postfix: UICaption });



////}


