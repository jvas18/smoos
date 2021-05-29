import { UserProfile } from '../enums/user-profile.enum';


export interface SessionUser {
  id: string;
  email: string;
  name: string;
  profile: UserProfile;
  avatar: string;
}