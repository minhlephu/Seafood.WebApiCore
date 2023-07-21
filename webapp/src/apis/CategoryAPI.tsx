import CategoryModel from "../models/category.model";
import BaseAPI from "./BaseAPI";

class CategoryAPI extends BaseAPI<CategoryModel>{
   
}

const categoryAPI = new CategoryAPI("categories");
export default categoryAPI;