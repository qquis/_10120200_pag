// CardToggle.tsx
import { useState } from "react";

interface CardProps {
  title: string;
  openDefault?: boolean;
  children: React.ReactNode;
}

export default function Card({ title, openDefault = false, children }: CardProps) {
  const [open, setOpen] = useState(openDefault);

  return (
    <div
      className="bg-white rounded-xl border border-gray-200 mb-4 transition-shadow hover:shadow-lg shadow-md flex-1"
      style={{
        boxShadow: "0 2px 8px rgba(0,0,0,0.08)",
        transition: "box-shadow 0.2s",
        minWidth: 220, // ajuste conforme necessário
        display: 'flex',
        flexDirection: 'column',
      }}
    >
      <button
        className="w-full bg-slate-200 flex items-center justify-between px-5 py-4 text-left focus:outline-none"
        onClick={() => setOpen((v) => !v)}
        type="button"
        aria-expanded={open}
      >
        <span className="font-sans text-gray-800 text-lg">{title}</span>
        <span
          className="ml-2 transition-transform"
          style={{ transform: open ? "rotate(90deg)" : "rotate(0deg)" }}
        >
          ▶
        </span>
      </button>
      {open && (
        <div className="px-5 pb-5 text-gray-700">
          {children}
        </div>
      )}
    </div>
  );
}
