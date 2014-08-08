$(function () {
    var availableTags = [
      "ActionScript",
      "AppleScript",
      "Asp",
      "BASIC",
      "C",
      "C++",
      "Clojure",
      "COBOL",
      "ColdFusion",
      "Erlang",
      "Fortran",
      "Groovy",
      "Haskell",
      "Java",
      "JavaScript",
      "Lisp",
      "Perl",
      "PHP",
      "Python",
      "Ruby",
      "Scala",
      "Scheme"
    ];
    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }

    $("#tags")
      // don't navigate away from the field on tab when selecting an item
      .bind("keydown", function (event) {
          if (event.keyCode === $.ui.keyCode.TAB &&
              $(this).autocomplete("instance").menu.active) {
              event.preventDefault();
          }
      })
      .autocomplete({
          minLength: 0,
          source: function (request, response) {
              // delegate back to autocomplete, but extract the last term
              response($.ui.autocomplete.filter(
                availableTags, extractLast(request.term)));
          },
          focus: function () {
              // prevent value inserted on focus
              return false;
          },
          select: function (event, ui) {
              var terms = split(this.value);
              // remove the current input
              terms.pop();
              // add the selected item
              terms.push(ui.item.value);
              // add placeholder to get the comma-and-space at the end
              terms.push("");
              this.value = terms.join(", ");
              return false;
          }
      });
});






































//$(function () {
//    var ajaxFormSubmit = function () {
//        var $form = $(this);

//        var options = {
//            url: $form.attr("action"),
//            type: $attr("method"),
//            data: $form.serialize()
//        };

//        $.ajax(options).done(function (data) {
//            var $target = $($form.attr("data-otf-target"));
//            $target.replaceWith(data);
//        })

//        return false;
//    };

//    var createAutocomplete = function () {
//        var $input = $(this);

//        var options = {
//            source: $input.attr("data-otf-autocomplete")
//        };

//        $input.autocomplete(options);
//    };

//    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
//    $("input[data-otf-autcomplete]").each(createAutocomplete);
//})












//$(function () {

//	    var ajaxFormSubmit = function () {
//	        var $form = $(this);

//	        var options = {
//	            url: $form.attr("action"),
//	            type: $form.attr("method"),
//	            data: $form.serialize()
//	        };

//	        $.ajax(options).done(function (data) {
//	            var $target = $($form.attr("data-otf-target"));
//	            var $newHtml = $(data);
//	            $target.replaceWith($newHtml);
//	            $newHtml.effect("highlight");
//	        });

//	        return false;
//	    };

//	    var submitAutocompleteForm = function (event, ui) {

//	        var $input = $(this);
//	        $input.val(ui.item.label);

//	        var $form = $input.parents("form:first");
//	        $form.submit();
//	    };

//	    var createAutocomplete = function () {
//	        var $input = $(this);

//	        var options = {
//	            source: $input.attr("data-otf-autocomplete"),
//	            select: submitAutocompleteForm
//	        };

//	        $input.autocomplete(options);
//	    };

//	    var getPage = function () {
//	        var $a = $(this);

//	        var options = {
//	            url: $a.attr("href"),
//	            data: $("form").serialize(),
//	            type: "get"
//	        };

//	        $.ajax(options).done(function (data) {
//	            var target = $a.parents("div.pagedList").attr("data-otf-target");
//	            $(target).replaceWith(data);
//	        });
//	        return false;

//	    };

//	    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
//	    $("input[data-otf-autocomplete]").each(createAutocomplete);

//	    $(".main-content").on("click", ".pagedList a", getPage);


//	});


$(function () {
    var availableTags = [
      "ActionScript",
      "AppleScript",
      "Asp",
      "BASIC",
      "C",
      "C++",
      "Clojure",
      "COBOL",
      "ColdFusion",
      "Erlang",
      "Fortran",
      "Groovy",
      "Haskell",
      "Java",
      "JavaScript",
      "Lisp",
      "Perl",
      "PHP",
      "Python",
      "Ruby",
      "Scala",
      "Scheme"
    ];
    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }

    $("#tags")
      // don't navigate away from the field on tab when selecting an item
      .bind("keydown", function (event) {
          if (event.keyCode === $.ui.keyCode.TAB &&
              $(this).autocomplete("instance").menu.active) {
              event.preventDefault();
          }
      })
      .autocomplete({
          minLength: 0,
          source: function (request, response) {
              // delegate back to autocomplete, but extract the last term
              response($.ui.autocomplete.filter(
                availableTags, extractLast(request.term)));
          },
          focus: function () {
              // prevent value inserted on focus
              return false;
          },
          select: function (event, ui) {
              var terms = split(this.value);
              // remove the current input
              terms.pop();
              // add the selected item
              terms.push(ui.item.value);
              // add placeholder to get the comma-and-space at the end
              terms.push("");
              this.value = terms.join(", ");
              return false;
          }
      });
});
