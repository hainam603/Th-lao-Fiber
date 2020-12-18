<template>
  <v-container class="fill-height">
    <v-row justify="space-around">
      <v-card width="100%">
        <v-img
          max-height="180px"
          max-width="100%"
          src="../../public/fibervnn.jpg"
        >
        </v-img>
        <v-app-bar
            flat
            color="rgba(0, 0, 0, 0)"
          >
            <v-toolbar-title class="title black--text pl-0">
              CHƯƠNG TRÌNH TÍNH THÙ LAO FIBER
            </v-toolbar-title>
          </v-app-bar>

        <v-card-text>
          <div class="font-weight-bold ml-8 mb-2">
            Chức năng
          </div>

          <v-timeline
            align-top
            dense
          >
            <v-timeline-item
              v-for="item in functions"
              :key="item.name"
              :color="item.color"
              small
            >
              <div>
                <div class="font-weight-normal">
                  <strong>{{ item.name }}</strong>
                </div>
                <div>{{ item.describe }}</div>
              </div>
            </v-timeline-item>
          </v-timeline>
        </v-card-text>
      </v-card>
    </v-row>
  </v-container>
</template>

<script>

// @ is an alias to /src
// import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'Home',
  components: {
    // HelloWorld
  },
  data: () => ({
    functions:[
      {name:"Danh sách phát triển mới fiber",
      describe:"Lấy danh sách các thuê bao phát triển mới theo tháng",
      color:"red"},
      {name:"Tính thù lao fiber lần 1",
      describe:"Lấy danh sách thù lao fiber lần 1",
      color:"green"},
      {name:"Tính thù lao fiber lần 2",
      describe:"Lấy danh sách thù lao fiber lần 2",
      color:"blue"},
    ],
    
  })
}
</script>
