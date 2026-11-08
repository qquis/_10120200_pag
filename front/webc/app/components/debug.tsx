'use client';
import { useState, useEffect } from 'react';

export default function DebugConsole() {
  const [logs, setLogs] = useState<string[]>([]);

  useEffect(() => {
    const originalLog = console.log;
    const originalError = console.error;

    console.log = (...args) => {
      setLogs(prev => [...prev.slice(-10), `LOG: ${JSON.stringify(args)}`]);
      originalLog(...args);
    };

    console.error = (...args) => {
      setLogs(prev => [...prev.slice(-10), `ERROR: ${JSON.stringify(args)}`]);
      originalError(...args);
    };

    return () => {
      console.log = originalLog;
      console.error = originalError;
    };
  }, []);

  if (process.env.NODE_ENV !== 'development') return null;

  return (
    <div className="fixed top-0 left-0 w-full bg-black text-green-400 text-xs p-2 z-50 max-h-40 overflow-y-auto">
      {logs.map((log, i) => (
        <div key={i}>{log}</div>
      ))}
    </div>
  );
}