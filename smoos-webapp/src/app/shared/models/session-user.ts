import { UserProfile } from '../enums/user-profile.enum';


export interface SessionUser {
  id: string;
  email: string;
  firstName: string;
  lastName?: string;
  fullName: string;
  profile: UserProfile;
  avatar: string;
}