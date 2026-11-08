'use client';

import { useState, useEffect } from 'react';
import { useRouter, usePathname } from 'next/navigation';

export default function Header() {
  const [activeSection, setActiveSection] = useState('home');
  const [isMenuOpen, setIsMenuOpen] = useState(false);
  const router = useRouter();
  const pathname = usePathname();

  const showSection = (sectionId: string) => {
    if (sectionId === 'acesso') {
      // Redirecionar para página de login ao invés de perfil
      router.push('/pages/login');
      return;
    }
    
    // Para outras seções, navegar para home se não estamos lá
    if (pathname !== '/') {
      router.push('/');
      return;
    }
    
    // Hide all sections
    const sections = document.querySelectorAll('.section');
    sections.forEach(section => section.classList.remove('active'));
    
    // Show selected section
    const targetSection = document.getElementById(sectionId);
    if (targetSection) {
      targetSection.classList.add('active');
    }
    
    // Update navigation
    const navLinks = document.querySelectorAll('.nav-link');
    navLinks.forEach(link => link.classList.remove('active'));
    
    // Add active class to clicked nav item
    const clickedLink = document.querySelector(`[href="#${sectionId}"]`);
    if (clickedLink) {
      clickedLink.classList.add('active');
    }
    
    // Update state
    setActiveSection(sectionId);
    setIsMenuOpen(false); // Fechar menu mobile após seleção
    
    // Scroll to top
    window.scrollTo(0, 0);
  };

  const showContactModal = () => {
    const modal = document.getElementById('contactModal');
    if (modal) {
      modal.classList.add('active');
      document.body.style.overflow = 'hidden';
    }
  };

  const closeContactModal = (event?: React.MouseEvent) => {
    if (event && event.target !== event.currentTarget) return;
    const modal = document.getElementById('contactModal');
    if (modal) {
      modal.classList.remove('active');
      document.body.style.overflow = 'auto';
    }
  };

  const copyToClipboard = (text: string, type: string) => {
    navigator.clipboard.writeText(text).then(() => {
      showNotification(`${type} copiado para a área de transferência!`, 'success');
    }).catch(() => {
      showNotification(`Erro ao copiar ${type.toLowerCase()}`, 'error');
    });
  };

  const callPhone = (number: string) => {
    window.open(`tel:+55${number}`, '_self');
  };

  const openWhatsApp = (number: string) => {
    const message = encodeURIComponent('Olá! Gostaria de saber mais sobre o Aniversário Premiado OXAN.');
    window.open(`https://wa.me/${number}?text=${message}`, '_blank', 'noopener,noreferrer');
  };

  const showNotification = (message: string, type: 'success' | 'error') => {
    const notification = document.createElement('div');
    notification.style.cssText = `
      position: fixed;
      top: 20px;
      right: 20px;
      background: ${type === 'success' ? '#16a34a' : '#dc2626'};
      color: white;
      padding: 1rem 2rem;
      border-radius: 10px;
      box-shadow: 0 5px 15px rgba(0,0,0,0.3);
      z-index: 10001;
      font-weight: bold;
      animation: slideInRight 0.3s ease;
    `;
    notification.textContent = message;
    document.body.appendChild(notification);
    
    setTimeout(() => {
      notification.style.animation = 'slideOutRight 0.3s ease';
      setTimeout(() => notification.remove(), 300);
    }, 3000);
  };

  useEffect(() => {
    // Add animation styles
    const style = document.createElement('style');
    style.textContent = `
      @keyframes slideInRight {
        from { transform: translateX(100%); opacity: 0; }
        to { transform: translateX(0); opacity: 1; }
      }
      @keyframes slideOutRight {
        from { transform: translateX(0); opacity: 1; }
        to { transform: translateX(100%); opacity: 0; }
      }
    `;
    document.head.appendChild(style);

    // Close modal with ESC
    const handleKeyDown = (e: KeyboardEvent) => {
      if (e.key === 'Escape') {
        closeContactModal();
      }
    };

    document.addEventListener('keydown', handleKeyDown);

    return () => {
      document.removeEventListener('keydown', handleKeyDown);
      if (document.head.contains(style)) {
        document.head.removeChild(style);
      }
    };
  }, []);

  return (
    <>
      <style jsx global>{`
        .header {
          background: #dc2626;
          padding: 1rem 0;
          box-shadow: 0 2px 10px rgba(0,0,0,0.1);
          position: sticky;
          top: 0;
          z-index: 1000;
        }
        .container {
          max-width: 1200px;
          margin: 0 auto;
          padding: 0 1rem;
        }
        .header-content {
          display: flex;
          justify-content: space-between;
          align-items: center;
          margin-bottom: 1rem;
        }
        .logo-section {
          display: flex;
          align-items: center;
          gap: 1rem;
          flex-wrap: wrap;
        }
        .logo-container {
          display: flex;
          align-items: center;
          gap: 1rem;
        }
        .logo-image {
          width: 60px;
          height: 60px;
          background: #1e3a8a;
          border-radius: 12px;
          display: flex;
          align-items: center;
          justify-content: center;
          color: white;
          font-weight: bold;
          font-size: 1.5rem;
          box-shadow: 0 4px 12px rgba(30, 58, 138, 0.3);
        }
        .logo {
          font-size: 1.6rem;
          font-weight: 700;
          color: white;
        }
        .anniversary-badge {
          background: linear-gradient(45deg, #f97316, #fb923c);
          color: white;
          padding: 0.8rem 1.5rem;
          border-radius: 25px;
          font-weight: bold;
          font-size: 1.1rem;
          text-align: center;
          box-shadow: 0 4px 15px rgba(249, 115, 22, 0.3);
        }
        
        /* Hamburger Menu */
        .hamburger {
          display: none;
          flex-direction: column;
          cursor: pointer;
          padding: 5px;
          background: transparent;
          border: none;
          border-radius: 8px;
          transition: background-color 0.3s;
        }
        .hamburger:hover {
          background: rgba(255, 255, 255, 0.1);
        }
        .hamburger span {
          width: 25px;
          height: 3px;
          background-color: white;
          margin: 3px 0;
          transition: 0.3s;
          border-radius: 2px;
        }
        
        /* Main Navigation */
        .main-nav {
          border-top: 2px solid rgba(255, 255, 255, 0.2);
          padding-top: 1rem;
        }
        .nav-list {
          display: flex;
          justify-content: center;
          list-style: none;
          margin: 0;
          padding: 0;
          gap: 2rem;
          flex-wrap: wrap;
        }
        .nav-link {
          text-decoration: none;
          color: white;
          font-weight: bold;
          padding: 0.8rem 1.5rem;
          border-radius: 25px;
          transition: all 0.3s ease;
          border: 2px solid transparent;
          background: linear-gradient(145deg, rgba(255,255,255,0.1), rgba(255,255,255,0.05));
          backdrop-filter: blur(10px);
          display: flex;
          align-items: center;
          gap: 0.5rem;
          cursor: pointer;
        }
        .nav-link:hover {
          background: linear-gradient(145deg, rgba(255,255,255,0.25), rgba(255,255,255,0.15));
          border-color: rgba(255, 255, 255, 0.6);
          box-shadow: 0 4px 15px rgba(0, 0, 0, 0.2);
          transform: translateY(-2px);
        }
        .nav-link.active {
          background: linear-gradient(145deg, rgba(255,255,255,0.3), rgba(255,255,255,0.2));
          border-color: rgba(255, 255, 255, 0.8);
          box-shadow: 0 4px 15px rgba(0, 0, 0, 0.25);
        }
        
        /* Modal Styles */
        .modal-overlay {
          position: fixed;
          top: 0;
          left: 0;
          width: 100%;
          height: 100%;
          background: rgba(0, 0, 0, 0.8);
          backdrop-filter: blur(10px);
          display: none;
          justify-content: center;
          align-items: center;
          z-index: 10000;
          animation: fadeIn 0.3s ease;
        }
        .modal-overlay.active {
          display: flex;
        }
        @keyframes fadeIn {
          from { opacity: 0; }
          to { opacity: 1; }
        }
        .contact-modal {
          background: white;
          border-radius: 25px;
          padding: 3rem;
          max-width: 500px;
          width: 90%;
          position: relative;
          box-shadow: 0 25px 50px rgba(0, 0, 0, 0.3);
          animation: modalSlideIn 0.4s cubic-bezier(0.4, 0, 0.2, 1);
        }
        @keyframes modalSlideIn {
          from { 
            transform: translateY(-50px) scale(0.9);
            opacity: 0;
          }
          to { 
            transform: translateY(0) scale(1);
            opacity: 1;
          }
        }
        .modal-header {
          text-align: center;
          margin-bottom: 2rem;
          color: #1e3a8a;
        }
        .modal-title {
          font-size: 2rem;
          font-weight: 700;
          margin-bottom: 0.5rem;
        }
        .modal-subtitle {
          color: #666;
          font-size: 1.1rem;
        }
        .contact-info {
          display: flex;
          flex-direction: column;
          gap: 1.5rem;
        }
        .contact-item {
          display: flex;
          align-items: center;
          gap: 1rem;
          padding: 1.5rem;
          background: #f8f9fa;
          border-radius: 15px;
          transition: all 0.3s ease;
          cursor: pointer;
          border: 2px solid transparent;
        }
        .contact-item:hover {
          background: #eff6ff;
          border-color: #1e3a8a;
          transform: translateY(-2px);
          box-shadow: 0 5px 15px rgba(30, 58, 138, 0.2);
        }
        .contact-icon {
          width: 50px;
          height: 50px;
          border-radius: 12px;
          display: flex;
          align-items: center;
          justify-content: center;
          font-size: 1.5rem;
          color: white;
          flex-shrink: 0;
        }
        .email-icon {
          background: linear-gradient(45deg, #dc2626, #ef4444);
        }
        .phone-icon {
          background: linear-gradient(45deg, #1e3a8a, #3b82f6);
        }
        .whatsapp-icon {
          background: linear-gradient(45deg, #16a34a, #22c55e);
        }
        .contact-details h4 {
          margin: 0 0 0.5rem 0;
          color: #1e3a8a;
          font-weight: 600;
        }
        .contact-details p {
          margin: 0;
          color: #666;
          font-weight: 500;
        }
        .close-modal {
          position: absolute;
          top: 1rem;
          right: 1rem;
          background: #f3f4f6;
          border: none;
          width: 40px;
          height: 40px;
          border-radius: 50%;
          display: flex;
          align-items: center;
          justify-content: center;
          cursor: pointer;
          font-size: 1.2rem;
          color: #666;
          transition: all 0.3s ease;
        }
        .close-modal:hover {
          background: #dc2626;
          color: white;
          transform: scale(1.1);
        }

        /* Responsive Design */
        @media (max-width: 768px) {
          .header {
            padding: 0.5rem 0;
          }
          
          .container {
            padding: 0 0.5rem;
          }
          
          .header-content {
            margin-bottom: 0.5rem;
          }
          
          .logo-section {
            flex-direction: column;
            gap: 0.8rem;
            align-items: flex-start;
          }
          
          .logo-container {
            gap: 0.8rem;
          }
          
          .logo-image {
            width: 50px;
            height: 50px;
            font-size: 1.2rem;
          }
          
          .logo {
            font-size: 1.3rem;
          }
          
          .anniversary-badge {
            font-size: 0.9rem;
            padding: 0.6rem 1rem;
          }
          
          /* Show hamburger menu */
          .hamburger {
            display: flex;
          }
          
          /* Hide main nav on mobile */
          .main-nav {
            display: none;
            position: absolute;
            top: 100%;
            left: 0;
            width: 100%;
            background: #dc2626;
            border-top: 2px solid rgba(255, 255, 255, 0.2);
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.3);
          }
          
          .main-nav.active {
            display: block;
          }
          
          .nav-list {
            flex-direction: column;
            gap: 0;
            padding: 1rem;
          }
          
          .nav-link {
            padding: 1rem;
            text-align: center;
            width: 100%;
            border-radius: 10px;
            margin-bottom: 0.5rem;
            justify-content: center;
          }
          
          /* Hamburger animation */
          .hamburger.active span:nth-child(1) {
            transform: rotate(-45deg) translate(-6px, 6px);
          }
          
          .hamburger.active span:nth-child(2) {
            opacity: 0;
          }
          
          .hamburger.active span:nth-child(3) {
            transform: rotate(45deg) translate(-6px, -6px);
          }
        }

        @media (max-width: 480px) {
          .logo {
            font-size: 1.1rem;
          }
          
          .anniversary-badge {
            font-size: 0.8rem;
            padding: 0.5rem 0.8rem;
          }
          
          .nav-link {
            font-size: 0.9rem;
            padding: 0.8rem;
          }
          
          .contact-modal {
            padding: 2rem 1.5rem;
          }
        }
      `}</style>

      <header className="header">
        <div className="container">
          <div className="header-content">
            <div className="logo-section">
              <div className="logo-container">
                <div className="logo-image">
                  <img 
                    src="/LOGO.png"
                    alt="Logo OXAN" 
                    style={{
                      width: '80px',
                      height: '80px',
                      objectFit: 'cover',
                      borderRadius: '5px'
                    }}
                  />
                </div>
                <div className="logo">OXAN ATACADISTA</div>
              </div>
              <div className="anniversary-badge">🎉 23 ANOS DE HISTÓRIA</div>
            </div>
            
            {/* Hamburger Button */}
            <button 
              className={`hamburger ${isMenuOpen ? 'active' : ''}`}
              onClick={() => setIsMenuOpen(!isMenuOpen)}
              aria-label="Menu"
            >
              <span></span>
              <span></span>
              <span></span>
            </button>
          </div>
          
          {/* Navigation Menu */}
          <nav className={`main-nav ${isMenuOpen ? 'active' : ''}`}>
            <ul className="nav-list">
              <li>
                <a 
                  href="#home" 
                  className={`nav-link ${activeSection === 'home' ? 'active' : ''}`}
                  onClick={() => showSection('home')}
                >
                  <span>🏠</span>HOME
                </a>
              </li>
              <li>
                <a 
                  href="#sorteados" 
                  className={`nav-link ${activeSection === 'sorteados' ? 'active' : ''}`}
                  onClick={() => showSection('sorteados')}
                >
                  <span>🏆</span>SORTEADOS
                </a>
              </li>
              <li>
                <a 
                  href="#regulamento" 
                  className={`nav-link ${activeSection === 'regulamento' ? 'active' : ''}`}
                  onClick={() => showSection('regulamento')}
                >
                  <span>📋</span>REGULAMENTO
                </a>
              </li>
              <li>
                <a 
                  href="#como-participar" 
                  className={`nav-link ${activeSection === 'como-participar' ? 'active' : ''}`}
                  onClick={() => showSection('como-participar')}
                >
                  <span>🎯</span>COMO PARTICIPAR
                </a>
              </li>
              <li>
                <a 
                  href="#acesso" 
                  className={`nav-link ${activeSection === 'acesso' ? 'active' : ''}`}
                  onClick={() => showSection('acesso')}
                >
                  <span>🔐</span>ACESSO
                </a>
              </li>
            </ul>
          </nav>
        </div>
      </header>

      {/* MODAL DE CONTATO */}
      <div id="contactModal" className="modal-overlay" onClick={closeContactModal}>
        <div className="contact-modal" onClick={(e) => e.stopPropagation()}>
          <button className="close-modal" onClick={closeContactModal}>✕</button>
          
          <div className="modal-header">
            <h2 className="modal-title">📞 Entre em Contato</h2>
            <p className="modal-subtitle">Estamos aqui para ajudar você!</p>
          </div>
          <div className="contact-info">
            <div className="contact-item" onClick={() => copyToClipboard('sac.aniversariooxan@oxan.com.br', 'E-mail')}>
              <div className="contact-icon email-icon">📧</div>
              <div className="contact-details">
                <h4>E-mail</h4>
                <p>sac.aniversariooxan@oxan.com.br</p>
              </div>
            </div>
            <div className="contact-item" onClick={() => callPhone('1127825200')}>
              <div className="contact-icon phone-icon">📞</div>
              <div className="contact-details">
                <h4>Telefone</h4>
                <p>(11) 2782-5200</p>
              </div>
            </div>
            <div className="contact-item" onClick={() => openWhatsApp('551127825211')}>
              <div className="contact-icon whatsapp-icon">💬</div>
              <div className="contact-details">
                <h4>WhatsApp</h4>
                <p>(11) 2782-5211</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}