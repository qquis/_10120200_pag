export default function htmlCRMHeaderStyle(): string {
        return `<!DOCTYPE html>
            <style>
            * {
                box-sizing: border-box;
            }
    
            body {
                margin: 0;
                padding: 0;
                font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                line-height: 1.6;
                color: #333333;
                background-color: #f5f5f5;
            }
    
            .email-container {
                max-width: 600px;
                margin: 0 auto;
                background-color: #ffffff;
                box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
                border-radius: 8px;
                overflow: hidden;
            }
    
            .header {
                background: linear-gradient(135deg, #2c3e50 0%, #3498db 100%);
                padding: 30px 20px;
                text-align: center;
                color: white;
            }
    
            .header .logo {
                max-width: 180px;
                height: auto;
                margin-bottom: 15px;
                border-radius: 4px;
            }
    
            .header .title {
                font-size: 24px;
                font-weight: 600;
                margin: 15px 0 10px 0;
                text-shadow: 0 2px 4px rgba(0, 0, 0, 0.2);
            }
    
            .header .subtitle {
                font-size: 16px;
                opacity: 0.9;
                font-weight: 300;
            }
    
            .content {
                padding: 30px 25px;
            }
    
            .content-section {
                margin-bottom: 25px;
                padding: 20px;
                background-color: #f8f9fa;
                border-left: 4px solid #3498db;
                border-radius: 4px;
            }
    
            .footer {
                background-color: #2c3e50;
                color: white;
                padding: 25px;
                text-align: center;
                font-size: 14px;
            }
    
            .footer .company-name {
                font-weight: 600;
                font-size: 16px;
                margin-bottom: 10px;
                color: #3498db;
            }
    
            .footer .contact-info {
                margin: 8px 0;
                opacity: 0.9;
            }
    
            .footer .contact-info a {
                color: #3498db;
                text-decoration: none;
            }
    
            .footer .contact-info a:hover {
                text-decoration: underline;
            }
    
            .divider {
                height: 1px;
                background: linear-gradient(to right, transparent, #ddd, transparent);
                margin: 20px 0;
            }
    
            a[x-apple-data-detectors] {
                color: inherit !important;
                text-decoration: inherit !important;
            }
    
            #MessageViewBody a {
                color: inherit;
                text-decoration: none;
            }
    
            p {
                line-height: 1.6;
                margin: 0 0 15px 0;
            }
    
            .desktop_hide,
            .desktop_hide table {
                mso-hide: all;
                display: none;
                max-height: 0px;
                overflow: hidden;
            }
    
            .image_block img+div {
                display: none;
            }
    
            @media (max-width:670px) {
                .email-container {
                    margin: 10px;
                    max-width: calc(100% - 20px);
                }
    
                .header {
                    padding: 20px 15px;
                }
    
                .header .title {
                    font-size: 20px;
                }
    
                .content {
                    padding: 20px 15px;
                }
    
                .content-section {
                    padding: 15px;
                }
    
                .footer {
                    padding: 20px 15px;
                }
    
                .desktop_hide table.icons-inner {
                    display: inline-block !important;
                }
    
                .icons-inner {
                    text-align: center;
                }
    
                .icons-inner td {
                    margin: 0 auto;
                }
    
                .mobile_hide {
                    display: none;
                }
    
                .row-content {
                    width: 100% !important;
                }
    
                .stack .column {
                    width: 100%;
                    display: block;
                }
    
                .mobile_hide {
                    min-height: 0;
                    max-height: 0;
                    max-width: 0;
                    overflow: hidden;
                    font-size: 0px;
                }
    
                .desktop_hide,
                .desktop_hide table {
                    display: table !important;
                    max-height: none !important;
                }
            }
        </style>` 
}
