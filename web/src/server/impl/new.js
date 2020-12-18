import repository from '../repository/repository';
const resource = "/new";
export default {
    Get_List_New(month, token) {
        return repository.get(`${resource}/Get_List_New?month=`+month,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    Get_List_News(year, token) {
        return repository.get(`${resource}/Get_List_News?year=`+year,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    Insert_List_New(month,token){
        return repository.post(`${resource}/Insert_List_New?month=`+month,month,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    Get_Info_ByID(ma_tb, token) {
        return repository.get(`${resource}/Get_Info_ByID?ma_tb=`+ma_tb,{ headers: {"Authorization" : `Bearer ${token}`} });
    },
    Insert(New, token) {
        return repository.put(`${resource}/Insert`,New,{ headers: {"Authorization" : `Bearer ${token}`} });
    },

   
   
}