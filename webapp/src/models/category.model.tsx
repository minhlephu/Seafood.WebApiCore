export default interface CategoryModel {
  id?: string;
  name?: string;
  note?: string;
  code?: string;
  icon?: string;
  isDeleted: boolean;
  deletedAt?: Date;
  deletedBy?: string;
  createdAt?: Date;
  createdBy?: string;
  updateAt?: Date;
  updateBy?: string;
}
