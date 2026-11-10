import type { Metadata } from "next";
//import { Inter } from "next/font/google";
import localFont from "next/font/local";
import "./globals.css";
import  PagMenu  from "./components/pagmenu";
import  TabsBar  from "./components/TabsBar";
import { AuthProvider } from "./context/context";
import { TabsProvider } from "./context/TabsContext";
import { PageStatesProvider } from "./context/PageStatesContext";
import Protect from "./protect";




//const inter = Inter({ subsets: ["latin"] });
const inter = localFont({
  src: [
    {
      path: "../../public/fonts/inter/Inter-Regular.woff2",
      weight: "400",
      style: "normal",
    },
    {
      path: "../../public/fonts/inter/Inter-Bold.woff2",
      weight: "700",
      style: "normal",
    },
    {
      path: "../../public/fonts/inter/Inter-Italic.woff2",
      weight: "400",
      style: "italic",
    },
    {
      path: "../../public/fonts/inter/Inter-BoldItalic.woff2",
      weight: "700",
      style: "italic",
    },
  ],
  variable: "--font-inter",
});

export const metadata: Metadata = {
  title: "Prime",
  description: "Gerenciamento OXAN",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    
    <html lang="en">
      <body className={inter.className}>
          <AuthProvider>
            <PageStatesProvider>
              <TabsProvider>
                <div>
                  <PagMenu />
                  <TabsBar />
                </div>
                <Protect>{children}</Protect>
              </TabsProvider>
            </PageStatesProvider>
          </AuthProvider>
      </body>
    </html>
    
  );
}
