import './globals.css'
import type { Metadata } from 'next'
import { Inter } from 'next/font/google'
import MainHeader from "./components/mainHeader";
import MainFooter from "./components/mainFooter";
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const inter = Inter({ subsets: ['latin'] })

export const metadata: Metadata = {
  title: 'Cheap Buy',
  description: 'Demo for Dustin.se',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <main className="flex min-h-screen flex-col items-center justify-between p-24">
        <MainHeader />
          {children}
          
        <ToastContainer />
        <MainFooter />
        </main>
      </body>
    </html>
  )
}
