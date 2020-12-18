<template>
  <v-card 
  elevation="2">
    <v-card-title>
        TẠO MỚI DANH SÁCH PHÁT TRIỂN MỚI FIBER 
        
        <v-spacer></v-spacer>
          <el-date-picker
            @change="datepickerClick()"
            v-model="year"
            type="year"
            placeholder="Chọn năm để xem"
            format="yyyy"
            value-format="yyyy">
          </el-date-picker>
    </v-card-title>
    <v-card-text>
        
        <template>   
            
            <v-data-table
                :headers="headers"
                :items="desserts"
                :items-per-page="10"
                :search="search"
                sort-by="calories"
                class="elevation-1"
                :footer-props="{'items-per-page-options':[10, 50, 100, 150, 200],
                showFirstLastPage: true,
                firstIcon: 'mdi-arrow-collapse-left',
                lastIcon: 'mdi-arrow-collapse-right',
                prevIcon: 'mdi-minus',
                nextIcon: 'mdi-plus'
                }"
                :loading="loading"
                loading-text="Đang lấy dữ liệu, xin chờ..."
 
            >
                <template v-slot:top>
                <v-toolbar
                    flat
                >
                    <v-toolbar-title>{{year}}</v-toolbar-title>
                    <v-divider
                    class="mx-4"
                    inset
                    vertical
                    ></v-divider>
                    <v-spacer></v-spacer>
                    <v-dialog
                    v-model="dialog"
                    max-width="500px"
                    >
                     <v-spacer></v-spacer>
                    <template v-slot:activator="{ on, attrs }">
                       
                        <v-btn
                        color="primary"
                        dark
                        class="mb-2"
                        v-bind="attrs"
                        v-on="on"
                        >
                        Thêm
                        </v-btn>
                        <v-spacer></v-spacer>
                        <v-text-field
                            v-model="search"
                            append-icon="mdi-magnify"
                            label="Tìm kiếm"
                            single-line
                            hide-details
                        ></v-text-field>
                    </template>
                    
                    <v-card>
                        <v-card-title>
                        <span class="headline">{{ formTitle }}</span>
                        </v-card-title>

                        <v-card-text>
                        <v-container>
                            <v-row>
                            <v-col
                                cols="12"
                                sm="6"
                                md="6"
                            >
                                <el-date-picker
                                    v-model="month"
                                    type="month"
                                    placeholder="Chọn tháng"
                                    format="MM/yyyy"
                                    value-format="MM/yyyy">
                                </el-date-picker>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="6"
                            >
                                <el-button @click="CreateNew()" icon="el-icon-edit-outline">Tạo mới danh sách</el-button>
                            </v-col>
                            
                            
                            </v-row>
                        </v-container>
                        </v-card-text>

                        <v-card-actions>
                        <v-spacer></v-spacer>
     
                        <v-btn
                            color="blue darken-1"
                            text
                            @click="close"
                        >
                            Đóng
                        </v-btn>
                        </v-card-actions>
                    </v-card>
                    </v-dialog>
                    <v-dialog v-model="dialogDelete" max-width="500px">
                    <v-card>
                        <v-card-title class="headline">Xóa dòng dữ liệu này?</v-card-title>
                        <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="blue darken-1" text @click="closeDelete">Hủy</v-btn>
                        <v-btn color="blue darken-1" text @click="deleteItemConfirm">Đồng ý</v-btn>
                        <v-spacer></v-spacer>
                        </v-card-actions>
                    </v-card>
                    </v-dialog>
                </v-toolbar>
                </template>
                <template v-slot:item.actions="{ item }">
                <v-icon
                    small
                    @click="deleteItem(item)"
                >
                    mdi-delete
                </v-icon>
                </template>
                <template v-slot:no-data>
                <v-btn
                    color="primary"
                    @click="Get_List_New()"
                >
                    Làm mới
                </v-btn>
                </template>
            </v-data-table>
            
            </template>
        <v-row>
            <v-snackbar
                v-model="snackbar"
                >
                {{ text }}
                <template v-slot:action="{ attrs }">
                    <v-btn
                    color="primary"
                    text
                    v-bind="attrs"
                    @click="snackbar = false"
                    >
                    Đóng
                    </v-btn>
                </template>
            </v-snackbar>
        </v-row>
    </v-card-text>
  </v-card>
</template>

<script>
import Factory from '@/server/factory/factory';
import common from '@/server/common/common';
const New = Factory.get('new');
export default {
    data() {
        return {

            //datetimepicker
            year:'2020',
            month:null,

            //Search Table
            search:null,
            //VUETIFY TABLE
            loading: false,
            dialog: false,
            dialogDelete: false,
            headers: [
                {text: '', value: 'actions', sortable: false, fixed: true },
                {text:"Tiêu đề" ,value:"tieude",align: 'start',  fixed: true ,width:"380"},
                {text:"Tháng" ,value:"thang", width:"180"},
                {text:"Năm" ,value:"nam", width:"180"},
                {text:"Số lượng thuê bao" ,value:"sl_tb", width:"200"},
                {text:"Ngày tạo" ,value:"ngay_tao" , width:"180"},
            ],
            desserts: [],
            editedIndex: -1,
            


        
            //snapbar

            snackbar: false,
            text: null,


            //userlogin
            ma_ND: null,
            ten_NV: null,
            token: null,
        }
    },
    watch: {
       
        dialog (val) {
            val || this.close()
        },
        dialogDelete (val) {
            val || this.closeDelete()
        },
    },
    computed: {
        formTitle () {
            return this.editedIndex === -1 ? 'Thêm mới' : 'Chỉnh sửa'
        },
    },
    created () {

        var self=this;
        //Get Info User Login
        var UserLogin = common.GetInfoUserLogin('token_session');
        if(!UserLogin)
            self.$router.push('/login');
        else
        {
            self.ten_NV=UserLogin.ten_NV;
            self.ma_ND=UserLogin.ma_ND;
            self.token=UserLogin.token;
        
        };

        //Get list News
        self.Get_List_News();

        //
    },
    methods: {
        CreateNew(){
            var self=this;
            if(self.month){
                New.Insert_List_New(self.month,self.token).then(response=>{
                    if(response.data.success){
                        self.text="Tạo mới danh sách Fiber thành công"
                        self.snackbar=true;
                        self.Get_List_News(self.year,self.token);
                    }
                    else
                    {
                        self.text="Đã tồn tại thông tin trong danh sách fiber muốn tạo mới"
                        self.snackbar=true;
                    }
                });
            self.close();
            }
        },
        datepickerClick(){
        if(this.year)
            this.Get_List_News();
        },
        Get_List_News() {
            var self=this;
            if(self.year){
                self.loading=true;
                self.text="Đang lấy dữ liệu, xin chờ...";
                self.snackbar=true;
                New.Get_List_News(self.year,self.token).then(response =>{
                    if(response.data.success && response.data.data.length){
                        self.desserts = response.data.data;
                        self.loading=false
                        self.text="Lấy dữ liệu hoàn tất";
                        self.snackbar=true;
                    }

                });
            }
            
            
        },

       

    //vuetify table


      deleteItem (item) {
        this.editedIndex = this.desserts.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialogDelete = true
      },

      deleteItemConfirm () {
        //delete
        this.desserts.splice(this.editedIndex, 1)
        this.closeDelete()
        console.log(this.editedItem);
      },

      close () {
        this.dialog = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      closeDelete () {
        this.dialogDelete = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

     
    
  
       
    },
}
</script>

<style>

</style>