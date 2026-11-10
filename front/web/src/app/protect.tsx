'use client';
import { useAuth } from "./context/context";
import { useRouter, usePathname } from "next/navigation";
import { useEffect } from "react";

export default function Protect({ children }: { children: React.ReactNode }) {
  const { user, sessionReady } = useAuth();
  const router = useRouter();
  const pathname = usePathname();

  useEffect(() => {
    if (!sessionReady) return;

    if (!user.user_name && !["/public", "/login", "/404"].includes(pathname)) {
      router.replace("/login");
    } else if (user.user_name && ["/", "/login"].includes(pathname)) {
      router.replace("/pages");
    }
  }, [sessionReady, user, pathname, router]);

  const isPublicPage = ["/login", "/public", "/404"].includes(pathname);
  const shouldRender = isPublicPage || (sessionReady && Boolean(user.user_name));
  
  return <>{shouldRender ? children : null}</>;
}