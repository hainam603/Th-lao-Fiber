export default{
    GetCookie(cname) {
        var name = cname + "=";
        var ca = document.cookie.split(';');
        for(var i = 0; i <ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0)==' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length,c.length);
            }
        }
        return "";
    },

    strToObj(str) {
        //convert string to object
        var obj = {};
        if (str && typeof str === "string") {
          var objStr = str.match(/\{(.)+\}/g);
          eval("obj =" + objStr);
        }
        return obj;
      },

    GetInfoUserLogin(cname){
        var cookie = this.GetCookie(cname);
        return this.strToObj(cookie);
    },

}