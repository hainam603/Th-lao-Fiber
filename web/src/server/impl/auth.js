import repository from '../repository/repository';
const resource = "/auth";
export default {
    auth(user) {
        return repository.post(`${resource}/login`,user);
    },
   
}