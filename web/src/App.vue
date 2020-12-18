<template>
  <v-app >

    <!-- menu -->
     
     <v-app-bar app color="blue darken-1" dark v-if="$route.meta.requiresAuth">
        
        <v-toolbar-Title>
          <v-img
            alt="VNPT Logo"
            class="shrink mr-2"
            contain
            src="../public/logo-vnpt.png"
            transition="scale-transition"
            width="70"
          />
        </v-toolbar-Title>
        <v-autocomplete
        v-model="searchSelect"
        :loading="searchLoading"
        :items="searchItems"
        :search-input.sync="searchInput"
        cache-items
        class="mx-4"
        flat
        hide-no-data
        hide-details
        label="Tìm kiếm"
        solo-inverted
      ></v-autocomplete>
        <v-spacer></v-spacer>
        <v-toolbar-items
          class="hidden-xs-only"
          v-for="(item,i) in menuItems"
          :key="i"
        >
          <v-btn text :to="item.path">
            <v-icon left dark>{{ item.icon }}</v-icon>
            <span class="mr-2">{{ item.title }}</span>
          </v-btn>

          <v-divider vertical></v-divider>
        </v-toolbar-items>
        <v-app-bar-nav-icon
          @click.stop="sidebar=!sidebar"
        ></v-app-bar-nav-icon>
      </v-app-bar>

      <!-- sidebar left -->

      <v-navigation-drawer 
      v-model="sidebar" temporary absolute bottom right width="300px" class="blue lighten-4">
          <v-list shaped>

            <v-list-group :value="true" prepend-icon="mdi-account-circle">
              <template v-slot:activator>
                <v-list-item-Title >{{ten_NV}}</v-list-item-Title>
              </template>

              <v-list-group :value="true" no-action sub-group>
                <template v-slot:activator>
                  <v-list-item-content>
                    <v-list-item-Title>Chức năng</v-list-item-Title>
                  </v-list-item-content>
                </template>

                <v-list-item v-for="(item,index) in functionsUser" :key="index" @click="clickFunctionUser(item.name)" link>
                  <v-list-item-icon>
                    <v-icon>{{item.icon}}</v-icon>
                  </v-list-item-icon>
                  <v-list-item-Title>{{item.name}}</v-list-item-Title>
                </v-list-item>
              </v-list-group>
            </v-list-group>
          </v-list>
        </v-navigation-drawer>

    <!-- main -->

    <v-main>
       <router-view/>
    </v-main>

    

    <!-- menu bottom -->
    <!-- <v-bottom-navigation
      v-model="valueMenuBottom"
      :input-value="activeMenuBottom"
      color="white"
      background-color="blue darken-1"
      dark
    >
      <v-btn>
        <span>Recents</span>

        <v-icon>mdi-history</v-icon>
      </v-btn>

      <v-btn>
        <span>Favorites</span>

        <v-icon>mdi-heart</v-icon>
      </v-btn>

      <v-btn>
        <span>Nearby</span>

        <v-icon>mdi-map-marker</v-icon>
      </v-btn>
    </v-bottom-navigation> -->
  
  </v-app>
</template>

<script>
// import HelloWorld from './components/HelloWorld';
import common from '@/server/common/common';

export default {
  name: 'App',

  components: {
    // HelloWorld,
  },

  data: () => ({
    //menu
      
      menuItems: [
          { title: 'Trang chủ', path: '/home', icon: 'mdi-home' },
          { title: 'Danh sách phát triển mới', path: '/new', icon: 'mdi-open-in-new' },
          { title: 'Tính thù lao lần 1', path: '/fee1', icon: 'mdi-account-network' },
          { title: 'Tính thù lao lần 2', path: '/fee2', icon: 'mdi-account-network-outline' }
      ],
      //sidebar menu
      sidebar: false,
      functionsUser:[],


      //searchBox
      searchItems: [],
      searchInput:null,
      searchLoading:false,
      searchSelect:null,
      
      //menuBottom
      valueMenuBottom:null,
      activeMenuBottom:null,

      //userlogin
      ma_ND: null,
      ten_NV: null,
      token: null,
      quyen_ID:null,


  }),

  created(){
    var self=this;
    //Load List Items Searchbox
    self.menuItems.forEach(item=>{
      self.searchItems.push(item.title);
    });

    //Get Info User Login
    var UserLogin = common.GetInfoUserLogin('token_session');
    if(!UserLogin)
      self.$router.push('/login');
    else
    {
      self.ten_NV=UserLogin.ten_NV;
      self.ma_ND=UserLogin.ma_ND;
      self.token=UserLogin.token;
      self.quyen_ID=UserLogin.quyen_ID;
      if(self.quyen_ID==1)
         self.functionsUser=[
          {name:"Quản trị", icon:"mdi-account-group"},
          {name:"Đăng xuất", icon:"mdi-logout"},
        ];
      else
        self.functionsUser=[
          {name:"Đăng xuất", icon:"mdi-logout"},
        ];
    }

  },
  watch:{
    searchInput: function(val){
      var self=this;
      self.searchLoading=true;
      if(self.searchItems.includes(val))
      {
        self.menuItems.forEach(item=>{
          if(item.title==val){
             self.$router.push(item.path);
          }
        });
      }
      self.searchLoading=false;
    }
  },
  methods:{
    //sidebar
    clickFunctionUser(val){
      if(val=="Quản trị")
        this.$router.push('/adminpage');
      else
        this.$router.push('/logout');
    },
    //get info user login
    
  }
};
</script>
<style scoped>

</style>
