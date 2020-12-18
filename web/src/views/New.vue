<template>
  <v-card 
  elevation="2">
    <v-card-title>
        DANH SÁCH PHÁT TRIỂN MỚI FIBER 
        
        <v-spacer></v-spacer>
          <el-date-picker
            @change="datepickerClick()"
            v-model="month"
            type="month"
            placeholder="Chọn tháng để xem"
            format="MM-yyyy"
            value-format="yyyyMM">
          </el-date-picker>
          <div class="export-excel">
            <download-excel 
            name="DANH SÁCH FIBER PHÁT TRIỂN MỚI"
            :fields="columns"
            :data="desserts">
                <el-button icon="el-icon-download">Excel</el-button>
            </download-excel>
          </div>
             <el-button @click="CreateNewClick()" icon="el-icon-edit-outline">Tạo mới danh sách</el-button>
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
                    <v-toolbar-title>{{month}}</v-toolbar-title>
                    <v-divider
                    class="mx-4"
                    inset
                    vertical
                    ></v-divider>
                    <v-spacer></v-spacer>
                    <v-dialog
                    v-model="dialog"
                    max-width="1000px"
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
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.ma_tb"
                                label="ma_tb"
                                append-icon="mdi-magnify" 
                                @click:append="Get_Info_ByID(editedItem.ma_tb)"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.tb_cd_dongquang"
                                label="tb_cd_dongquang"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.huy_truoc_30ngay"
                                label="huy_truoc_30ngay"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.khongthuoc_khuvuc_pttb"
                                label="khongthuoc_khuvuc_pttb"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.thang_hoamang"
                                label="thang_hoamang"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.ngay_hoamang"
                                label="ngay_hoamang"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.ngay_ins"
                                label="ngay_ins"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.trangthai"
                                label="trangthai"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.goi_tratruoc"
                                label="goi_tratruoc"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.tocdo_id"
                                label="tocdo_id"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.ma_nvkt_tt"
                                label="ma_NVKT_TT"
                                ></v-text-field>
                            </v-col>
                             <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.id_nvkt_tt"
                                label="id_nvkt_tt"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.hdtb_id"
                                label="hdtb_id"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.hdkh_id"
                                label="hdkh_id"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.thuebao_id"
                                label="thuebao_id"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.kieuld_id"
                                label="kieuld_id"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.ma_gd"
                                label="ma_gd"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.phongbh"
                                label="phongbh"
                                ></v-text-field>
                            </v-col>
                             <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.phongbh_id"
                                label="phongbh_id"
                                ></v-text-field>
                            </v-col>
                             <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.ten_tb"
                                label="ten_tb"
                                ></v-text-field>
                            </v-col>
                             <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.diachi_ld"
                                label="diachi_ld"
                                ></v-text-field>
                            </v-col>
                             <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.ngay_tt"
                                label="ngay_tt"
                                ></v-text-field>
                            </v-col>
                             <v-col
                                cols="12"
                                sm="6"
                                md="2"
                            >
                                <v-text-field
                                v-model="editedItem.tb_dungthu"
                                label="tb_dungthu"
                                ></v-text-field>
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
                            Hủy
                        </v-btn>
                        <v-btn
                            color="blue darken-1"
                            text
                            @click="save"
                        >
                            Đồng ý
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
                    class="mr-2"
                    @click="editItem(item)"
                >
                    mdi-pencil
                </v-icon>
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
                 <!-- <template v-slot:body="{ items }">
                    <tbody>
                    <tr v-for="(item, key) in items" :key="item.stt">
                        <td>{{ key+1 }}</td>
                        <td>{{ item.ma_tb }}</td>
                        <td>{{ item.tb_cd_dongquang }}</td>
                        <td>{{ item.huy_truoc_30ngay }}</td>
                        <td>{{ item.khongthuoc_khuvuc_pttb }}</td>
                        <td>{{ item.thang_hoamang }}</td>
                        <td>{{ item.ngay_hoamang }}</td>
                        <td>{{ item.ngay_ins }}</td>
                        <td>{{ item.trangthai }}</td>
                        <td>{{ item.goi_tratruoc }}</td>
                        <td>{{ item.tocdo_id }}</td>
                        <td>{{ item.ma_NVKT_TT }}</td>
                        <td>{{ item.hdtb_id }}</td>
                        <td>{{ item.hdkh_id }}</td>
                        <td>{{ item.thuebao_id }}</td>
                        <td>{{ item.kieuld_id }}</td>
                        <td>{{ item.ma_gd }}</td>
                        <td>{{ item.phongbh }}</td>
                        <td>{{ item.phongbh_id }}</td>
                        <td>{{ item.ten_tb }}</td>
                        <td>{{ item.diachi_ld }}</td>
                        <td>{{ item.ngay_tt }}</td>
                        <td>{{ item.tb_dungthu }}</td>
                        <td>{{ item.ngay_tao }}</td>       
                    </tr>
                    </tbody>
                </template> -->
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
            month:null,

            //Search Table
            search:null,
            //VUETIFY TABLE
            loading: false,
            dialog: false,
            dialogDelete: false,
            headers: [
                {text: '', value: 'actions', sortable: false, fixed: true },
                {text:"ma_tb" ,value:"ma_tb",align: 'start',  fixed: true ,width:"180"},
                {text:"tb_cd_dongquang" ,value:"tb_cd_dongquang", width:"180"},
                {text:"huy_truoc_30ngay" ,value:"huy_truoc_30ngay", width:"180"},
                {text:"khongthuoc_khuvuc_pttb" ,value:"khongthuoc_khuvuc_pttb", width:"200"},
                {text:"thang_hoamang" ,value:"thang_hoamang" , width:"180"},
                {text:"ngay_hoamang" ,value:"ngay_hoamang", width:"180"},
                {text:"ngay_ins" ,value:"ngay_ins" , width:"180"},
                {text:"trangthai" ,value:"trangthai" , width:"180"},
                {text:"goi_tratruoc" ,value:"goi_tratruoc" , width:"180"},
                {text:"tocdo_id" ,value:"tocdo_id" , width:"180"},
                {text:"ma_nvkt_tt" ,value:"ma_nvkt_tt" , width:"180"},
                {text:"id_nvkt_tt" ,value:"id_nvkt_tt" , width:"180"},
                {text:"hdtb_id" ,value:"hdtb_id", width:"180"},
                {text:"hdkh_id" ,value:"hdkh_id", width:"180"},
                {text:"thuebao_id" ,value:"thuebao_id" , width:"180"},
                {text:"kieuld_id" ,value:"kieuld_id" , width:"180"},
                {text:"ma_gd" ,value:"ma_gd", width:"180"},
                {text:"phongbh" ,value:"phongbh" , width:"180"},
                {text:"phongbh_id" ,value:"phongbh_id" , width:"180"},
                {text:"diachi_ld" ,value:"diachi_ld" ,  width:"380"},
                {text:"ngay_tt" ,value:"ngay_tt", width:"180"},
                {text:"tb_dungthu" ,value:"tb_dungthu", width:"180"},
                {text:"ngay_tao" ,value:"ngay_tao", width:"180"},
                
            ],
            desserts: [],
            editedIndex: -1,
            editedItem: {
                ma_tb: "ma_tb",
                tb_cd_dongquang: "tb_cd_dongquang",
                huy_truoc_30ngay: "huy_truoc_30ngay",
                khongthuoc_khuvuc_pttb: "khongthuoc_khuvuc_pttb",
                thang_hoamang: "thang_hoamang",
                ngay_hoamang: "ngay_hoamang",
                ngay_ins: "ngay_ins",
                trangthai: "trangthai",
                goi_tratruoc: "goi_tratruoc",
                tocdo_id: "tocdo_id",
                ma_nvkt_tt: "ma_nvkt_tt",
                id_nvkt_tt: "id_nvkt_tt",
                hdtb_id: "hdtb_id",
                hdkh_id: "hdkh_id",
                thuebao_id: "thuebao_id",
                kieuld_id: "kieuld_id",
                ma_gd: "ma_gd",
                phongbh: "phongbh",
                phongbh_id: "phongbh_id",
                ten_tb: "ten_tb",
                diachi_ld: "diachi_ld",
                ngay_tt: "ngay_tt",
                tb_dungthu: "tb_dungthu",
                ngay_tao: "ngay_tao"
            },            
            defaultItem: {
                 ma_tb: "ma_tb",
                tb_cd_dongquang: "tb_cd_dongquang",
                huy_truoc_30ngay: "huy_truoc_30ngay",
                khongthuoc_khuvuc_pttb: "khongthuoc_khuvuc_pttb",
                thang_hoamang: "thang_hoamang",
                ngay_hoamang: "ngay_hoamang",
                ngay_ins: "ngay_ins",
                trangthai: "trangthai",
                goi_tratruoc: "goi_tratruoc",
                tocdo_id: "tocdo_id",
                ma_nvkt_tt: "ma_nvkt_tt",
                id_nvkt_tt: "id_nvkt_tt",
                hdtb_id: "hdtb_id",
                hdkh_id: "hdkh_id",
                thuebao_id: "thuebao_id",
                kieuld_id: "kieuld_id",
                ma_gd: "ma_gd",
                phongbh: "phongbh",
                phongbh_id: "phongbh_id",
                ten_tb: "ten_tb",
                diachi_ld: "diachi_ld",
                ngay_tt: "ngay_tt",
                tb_dungthu: "tb_dungthu",
                ngay_tao: "ngay_tao"
            },

             pagination: {
                rowsPerPage: 50
                }, 

            //export excel
            columns:
            {
                "ma_tb": "ma_tb",
                "tb_cd_dongquang": "tb_cd_dongquang",
                "huy_truoc_30ngay": "huy_truoc_30ngay",
                "khongthuoc_khuvuc_pttb": "khongthuoc_khuvuc_pttb",
                "thang_hoamang": "thang_hoamang",
                "ngay_hoamang": "ngay_hoamang",
                "ngay_ins": "ngay_ins",
                "trangthai": "trangthai",
                "goi_tratruoc": "goi_tratruoc",
                "tocdo_id": "tocdo_id",
                "ma_nvkt_tt": "ma_nvkt_tt",
                "id_nvkt_tt": "id_nvkt_tt",
                "hdtb_id": "hdtb_id",
                "hdkh_id": "hdkh_id",
                "thuebao_id": "thuebao_id",
                "kieuld_id": "kieuld_id",
                "ma_gd": "ma_gd",
                "phongbh": "phongbh",
                "phongbh_id": "phongbh_id",
                "ten_tb": "ten_tb",
                "diachi_ld": "diachi_ld",
                "ngay_tt": "ngay_tt",
                "tb_dungthu": "tb_dungthu",
                "ngay_tao": "ngay_tao"
            },


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

        //Get list New

        //self.Get_List_New();
    },
    methods: {
        Get_Info_ByID(ma_tb){
            console.log(ma_tb);
            var self=this;
            self.loading=true;
            self.text="Đang lấy dữ liệu của thuê bao";
            self.snackbar=true;
            New.Get_Info_ByID(ma_tb,self.token).then(response => {
                if(response.data.success && response.data.data.length){
                    response.data.data.forEach(element => {
                        this.$set(this.editedItem, "tb_cd_dongquang", element.tb_cd_dongquang);
                        this.$set(this.editedItem, "huy_truoc_30ngay", element.huy_truoc_30ngay);
                        this.$set(this.editedItem, "khongthuoc_khuvuc_pttb", element.khongthuoc_khuvuc_pttb);
                        this.$set(this.editedItem, "thang_hoamang", element.thang_hoamang);
                        this.$set(this.editedItem, "ngay_hoamang", element.ngay_hoamang);
                        this.$set(this.editedItem, "ngay_ins", element.ngay_ins);
                        this.$set(this.editedItem, "trangthai", element.trangthai);
                        this.$set(this.editedItem, "goi_tratruoc", element.goi_tratruoc);
                        this.$set(this.editedItem, "tocdo_id", element.tocdo_id);
                        this.$set(this.editedItem, "ma_NVKT_TT", element.ma_NVKT_TT);
                        this.$set(this.editedItem, "hdtb_id", element.hdtb_id);
                        this.$set(this.editedItem, "thuebao_id", element.thuebao_id);
                        this.$set(this.editedItem, "kieuld_id", element.kieuld_id);
                        this.$set(this.editedItem, "ma_gd", element.ma_gd);
                        this.$set(this.editedItem, "phongbh", element.phongbh);
                        this.$set(this.editedItem, "phongbh_id", element.phongbh_id);
                        this.$set(this.editedItem, "ten_tb", element.ten_tb);
                        this.$set(this.editedItem, "diachi_ld", element.diachi_ld);
                        this.$set(this.editedItem, "ngay_tt", element.ngay_tt);
                        this.$set(this.editedItem, "tb_dungthu", element.tb_dungthu);
                        this.$set(this.editedItem, "ngay_tao", element.ngay_tao);
                    });
                    self.loading=false;
                    self.text="Lấy dữ liệu hoàn tất";
                    self.snackbar=true;
                }
                else { 
                    self.loading=false;
                    self.text="Thuê bao này không có trong dữ liệu, có thể thêm vào"
                    self.snackbar=true;
                }
            });
        },
        CreateNewClick(){
            this.$router.push('/createnew')
        },
        datepickerClick(){
        if(this.month)
            this.Get_List_New();
        },
        Get_List_New() {
            var self=this;
            self.loading=true;
            self.text="Đang lấy dữ liệu, xin chờ...";
            self.snackbar=true;
            New.Get_List_New(self.month,self.token).then(response =>{
                if(response.data.success && response.data.data.length){
                    self.desserts = response.data.data;
                    self.loading=false
                    self.text="Lấy dữ liệu hoàn tất";
                    self.snackbar=true;
                }

            });
            
            
        },

       

    //vuetify table

      editItem (item) {
        console.log(item);
        this.editedIndex = this.desserts.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialog = true
      },

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

      save () {
        if (this.editedIndex > -1) {
            //edit
          Object.assign(this.desserts[this.editedIndex], this.editedItem)
          console.log(editedItem);
        } else {
            //insert
        //   this.desserts.push(this.editedItem)
        //   console.log(editedItem);
        New.Insert(this.editedItem,this.token).then(
                response=>{
                    console.log(response);
                }
            ) 
        }
        this.close()
      },
    
  
       
    },
}
</script>

<style>

</style>