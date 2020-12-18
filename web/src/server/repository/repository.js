import axios from "axios";
const baseDomain = "http://localhost:58172";
const baseUrl = `${baseDomain}/api`;
const instance = axios.create({
  baseURL: baseUrl,
  // Wait for 5 seconds
  // headers: {
  //   'authorization': `Bearer ${token}`,
  // }
});
function getTokenByLocal() {
  var section_local = getCookie("token_session");
  if (section_local) {
    var tok = strToObj(getCookie("token_session"));
    // console.log(tok.token);
    return tok.token;
  }
  return "";

}
function getCookie(cname) {
  //get cookie by local
  var name = cname + "=";
  var decodedCookie = decodeURIComponent(document.cookie);
  var ca = decodedCookie.split(";");
  for (var i = 0; i < ca.length; i++) {
    var c = ca[i];
    while (c.charAt(0) === " ") {
      c = c.substring(1);
    }
    if (c.indexOf(name) === 0) {
      return c.substring(name.length, c.length);
    }
  }
  return "";
}

function strToObj(str) {
  //convert string to object
  var obj = {};
  if (str && typeof str === "string") {
    var objStr = str.match(/\{(.)+\}/g);
    eval("obj =" + objStr);
  }
  return obj;
}
export default instance;