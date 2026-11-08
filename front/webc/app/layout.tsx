import DebugConsole from './components/debug';
import type { Metadata } from "next";
import { Geist, Geist_Mono } from "next/font/google";
import "./globals.css";
import Header from '@/app/components/Header';
import Footer from '@/app/components/Footer';
import { AuthProvider } from './context/context';
import ProtectedRoute from '@/app/components/ProtectedRoute';

const geistSans = Geist({
  variable: "--font-geist-sans",
  subsets: ["latin"],
});

const geistMono = Geist_Mono({
  variable: "--font-geist-mono",
  subsets: ["latin"],
});

export const metadata: Metadata = {
  title: "Aniversário Premiado OXAN - 23 Anos",
  description: "Celebrando 23 anos com você!",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="pt-BR">
      <head>
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <link href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700;800;900&display=swap" rel="stylesheet" />
      </head>
      <body
        className={`${geistSans.variable} ${geistMono.variable} antialiased`}
        style={{
          boxSizing: 'border-box',
          margin: 0,
          padding: 0,
          fontFamily: "'Neue Helvetica', 'Helvetica Neue', 'Inter', -apple-system, BlinkMacSystemFont, sans-serif",
          background: '#ffffff',
          minHeight: '100vh',
          display: 'flex',
          flexDirection: 'column'
        }}
      >
        <DebugConsole />
        <AuthProvider>
          <ProtectedRoute>
            <Header />
            <main style={{ flex: 1 }}>
              {children}
            </main>
            <Footer />
          </ProtectedRoute>
        </AuthProvider>
      </body>
    </html>
  );
}
