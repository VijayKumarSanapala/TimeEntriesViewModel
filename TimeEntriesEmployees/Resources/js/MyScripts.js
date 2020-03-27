function ValidatePasswordChange(pword) {
    var password_regex1 = /([a-z].*[A-Z])|([A-Z].*[a-z])([0-9])+([!,%,&,@,#,$,^,*,?,_,~])/;
    var password_regex2 = /([0-9])/;
    var password_regex3 = /([!,%,&,@,#,$,^,*,?,_,~])/;


    if (pword.length < 8) {
        return "Minimum Password length 8";
    }
    else if (password_regex1.test(pword)) {
        return "Password should contain <br/>1. Atleast 1 Upper Letter <br>2. One digit <br>3. One Special Charecter";
    }
    else {
        return "OK";
    }
}


//var GlobalUrl = "http://www.glsms.com";
var GlobalUrl = "http://localhost:55236";
//var GlobalUrl = "http://14.98.166.66/SchoolMgmt";

