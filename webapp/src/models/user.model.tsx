export default interface UserModel {
  Id: string;
  Username: string;
  DisplayName?: string;
  Avarta?: string;
  Birthday?: string;
  Sex?: number;
  Mobile: string;
  Email?: string;
  Company?: string;
  Roles?: string;
  IsAdminUser?: boolean;
  IsLocked?: boolean;
  Session?: string;
  SessionId?: string;
  IsDeleted: boolean;
  DeletedAt?: Date;
  DeletedBy?: string;
  CreatedAt?: Date;
  CreatedBy?: string;
  UpdateAt?: Date;
  UpdateBy?: string;
}
