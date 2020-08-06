(function () {
  $.validator.setDefaults({
    ignore: ":hidden .ignore",
  });
  $(document).ready(function () {
    var btnSave = $("button.buttonSave");
    btnSave.on("click", save);

    function save(e) {
      var form = $(e.target.closest("form"));
      form.data("validator").settings.ignore =
        ".data-val-ignore, :hidden, :disabled";
      var validator = form.validate();
      resetForm(form);

      var checkboxOne = form.find("input[name=ConfirmationOne]");
      if (e.target.name === "saveAsAdmin2") {
        $(checkboxOne[0]).attr("disabled", true);
      }
      //validator.settings.ignore='.ignore';

      if (!form.valid()) {
        console.log("validation failed");
        e.preventDefault();
        $(checkboxOne[0]).attr("disabled", false);
        return false;
      }
      console.log("validation passed");
      alert("submitted");
      //form.submit();
    }

    function resetForm(form) {
      var validator = form.validate();
      validator.resetForm();
      validator.reset();
      form
        .find("[data-valmsg-replace]")
        .removeClass("field-validation-error")
        .addClass("field-validation-valid")
        .empty();
    }
  });
})();
