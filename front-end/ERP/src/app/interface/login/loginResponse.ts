export interface LoginResponse {
  success: boolean;
  message: string;
  data?: {
    token: string;
    expiresIn: number;
  };
}
