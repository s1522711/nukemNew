$("form").submit(function() {
    var _txt1 = $('#passwordInput').val();
    var _txt2 = $('#passwordConfirmInput').val();
    
    if (_txt1 == _txt2)
    {
       return true;
    }
    else
    {
      alert('the two passwords must match!');
      return false;
    }
  });