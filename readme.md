# ✅ Production Readiness Checklist (.NET Minimal API)

Checklist ini digunakan untuk memastikan aplikasi **.NET (Minimal API + Clean Architecture)** siap digunakan di **production environment**.

---

## 🔐 1. Security

- [x] HTTPS only (HSTS aktif di production)
- [x] Secrets via Environment / Secret Manager (❌ hardcode)
- [ ] JWT / OAuth2 authentication
  - [ ] Token expiry
  - [ ] Refresh token
- [ ] Role-based authorization
- [ ] Policy-based authorization
- [x] CORS restrictif (origin spesifik)
- [ ] Rate limiting (IP / user-based)
- [ ] Input validation (FluentValidation)
- [ ] SQL Injection safe (EF Core parameterized query)
- [ ] Detailed error disabled di production
- [ ] Security headers
  - [ ] X-Content-Type-Options
  - [ ] X-Frame-Options
  - [ ] X-XSS-Protection
  - [ ] Content-Security-Policy

---

## 🧱 2. Architecture & Code Quality

- [ ] Clean Architecture enforced
  - [ ] Domain ❌ tidak depend ke Infrastructure
- [ ] CQRS separation (Command ≠ Query)
- [ ] No DbContext di Controller / Endpoint
- [ ] Use Case / Application Service only
- [ ] DTO mapping (AutoMapper / manual)
- [ ] Async everywhere
- [ ] CancellationToken support
- [ ] No static mutable state
- [ ] SOLID principles applied

---

## 🗄️ 3. Database & Data

- [ ] EF Core migrations ready
- [ ] Connection pooling enabled
- [ ] Retry policy for transient failure
- [ ] Proper indexing
- [ ] Soft delete implemented (if needed)
- [ ] Transaction boundary jelas
- [ ] Read / Write separation (optional)
- [ ] Backup strategy defined
- [ ] Restore process tested

---

## 🚀 4. Performance

- [ ] Response compression enabled
- [ ] Caching strategy
  - [ ] In-memory cache
  - [ ] Redis (optional)
- [ ] Pagination on list endpoints
- [ ] No unbounded query
- [ ] AsNoTracking for read queries
- [ ] Avoid N+1 query
- [x] Kestrel configured explicitly
- [x] Server header disabled
- [x] Request size limit configured
- [x] Request timeout configured
- [x] HTTPS redirection enabled
- [x] HSTS enabled (production)
- [ ] HTTP/2 enabled (optional)

---

## 🔁 5. Resilience & Reliability

- [ ] Global exception handler
- [ ] Retry policy
- [ ] Circuit breaker
- [ ] Graceful shutdown
- [ ] Health check endpoints
- [ ] Idempotency for critical endpoints
- [ ] Dead letter handling (for async processing)

---

## 📊 6. Logging, Metrics & Tracing (Observability)

- [ ] Structured logging
- [ ] Correlation ID
- [ ] Request logging (no PII)
- [ ] Response logging (no PII)
- [ ] Metrics collected
  - [ ] CPU
  - [ ] Memory
  - [ ] Request rate
  - [ ] Error rate
- [ ] Distributed tracing
- [ ] Log level per environment

---

## 🧪 7. Testing

- [ ] Unit tests (Domain)
- [ ] Unit tests (Application)
- [ ] Integration tests (API)
- [ ] Integration tests (Database)
- [ ] Isolated test database
- [ ] Minimum test coverage defined
- [ ] Smoke test in pipeline

---

## ⚙️ 8. Configuration & Environment

- [ ] Environment-based configuration
- [ ] Feature flags implemented
- [ ] Configuration validation on startup
- [ ] No magic numbers
- [ ] Timezone consistency (UTC)

---

## 📦 9. CI / CD

- [ ] Build on pull request
- [ ] Automated tests on PR
- [ ] EF migration run automatically
- [ ] Docker image scan
- [ ] Zero-downtime deploy
  - [ ] Blue-Green
  - [ ] Rolling update
- [ ] Rollback strategy
- [ ] Semantic versioning (SemVer)

---

## 🌍 10. API Best Practices

- [ ] OpenAPI / Swagger enabled
- [ ] API versioning
- [ ] Consistent response format
- [ ] Meaningful HTTP status codes
- [ ] ProblemDetails (RFC 7807)

---

## 🧠 11. Operasional

- [ ] Liveness probe
- [ ] Readiness probe
- [ ] Alerting
  - [ ] Error rate
  - [ ] Latency
- [ ] Runbook documented
- [ ] Monitoring dashboard
- [ ] Audit log (if handling financial / sensitive data)

---

## 🚦 Go-Live Criteria (Minimal)

Aplikasi **boleh go-live** jika minimal memenuhi:

- [x] HTTPS enabled
- [ ] Global exception handling
- [ ] Authentication & authorization
- [ ] Logging + correlation ID
- [ ] Health check endpoint
- [ ] Database migration ready
- [ ] Backup strategy defined

---
