export interface AppWindow {
  id: number;
  title: string;
  icon: string;
  content: string;
  fullscreen: boolean;
  width: number;
  height: number;
  top: number;
  left: number;
  zIndex: number;
}