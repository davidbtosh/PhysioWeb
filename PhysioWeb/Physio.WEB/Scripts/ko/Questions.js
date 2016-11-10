
var answer = 0;


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

}


var reset_slider = function () {
    
    $("#slider-container-inner").remove();
    $("#slider-container-outer").append("<div id='slider-container-inner'><div id='ir-slider'></div></div>")
    //create_slider();
}


var get_slider_value = function () {
    return answer;
}


$(document).ready(function () {

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

    self.CurrentQuestion = ko.computed(function () {
        return self.QuestionSet()[self.QuestionIndex()]
    });

    
    self.SubmitQuestion = function (item, event) {

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

                }
                else {
                                      
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

                reset_slider();
                create_slider(self.CurrentQuestion().UIcaption());
           
            }
        })
        .fail();

    }
    

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
    
}





