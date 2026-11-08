'use client';
import { useRouter, usePathname } from 'next/navigation';
import { useState } from 'react';
import Image from 'next/image';

export default function OxanHome() {
  const router = useRouter();

  const editWinnerBanner = (bannerId: number) => {
    alert(`Editor de Banner do Ganhador #${bannerId}`);
  };

  const editPartner = (partnerId: number) => {
    alert(`Editor de Patrocinador #${partnerId}`);
  };

  const editBrand = (brandId: number) => {
    alert(`Editor de Marca #${brandId}`);
  };

  const editRegulamento = () => {
    alert(`Editor de Regulamento`);
  };

  const editSteps = () => {
    alert(`Editor de Como Participar`);
  };

  const editAccess = () => {
    alert(`Configurador de Acesso`);
  };

  const editMainBanner = () => {
    alert(`Editor de Banner Principal`);
  };

  return (
    <div style={{fontFamily: 'Arial, sans-serif'}}>
      <style jsx global>{`
        body {
          margin: 0;
          padding: 0;
        }
        
        .section {
          display: none;
        }
        .section.active {
          display: block;
        }
        
        .banner-container {
          position: relative;
          width: 70vw;
          height: 40vh;
          min-height: 250px;
          max-height: 400px;
          overflow: hidden;
          background: #f0f0f0;
          margin: 2rem auto 0;
          border-radius: 15px;
          box-shadow: 0 4px 20px rgba(0,0,0,0.1);
        }
      `}</style>

      {/* Aqui você pode adicionar o conteúdo das seções */}
      
    </div>
  );
}
