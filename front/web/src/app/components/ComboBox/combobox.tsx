import React from 'react';

type SelectPadraoProps = {
  value: string;
  onChange: (e: React.ChangeEvent<HTMLSelectElement>) => void;
  children: React.ReactNode;
  className?: string;
};


export default function PrimeComboBox({ value, onChange, children, className }: SelectPadraoProps) {
  return (
    <select
      value={value}
      onChange={onChange}
      className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent"
    >
      {children}
    </select>
  );
}