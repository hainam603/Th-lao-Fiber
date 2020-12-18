import authrepository from '../impl/auth';
import newrepository from '../impl/new';



const responsitories = {
    auth: authrepository,
    new: newrepository,

  };
  export default {
    get: name => responsitories[name]
  };