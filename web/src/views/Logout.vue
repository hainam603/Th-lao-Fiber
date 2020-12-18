<template>
  
</template>

<script>
export default {
    created () {
        console.log("logout");
        var self=this;
        document.cookie = "token_session=; expires=Thu, 01 Jan 1970 00:00:00 UTC";
    //   localStorage.setItem('ds_nguoidung','');
    //   localStorage.ds_chucnang='';
    //   self.islogin = false;
    //   self.selectComponent='loginComponent';
        self.$router.push({ name: "Login" });
    },
}
</script>

<style>

</style>